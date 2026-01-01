//
//  Renderer.swift
//  ParticleEditor
//
//  Created by Brandon Mantzey on 12/11/25.
//
//  https://bmantzey.dev

import MetalKit
import simd

final class Renderer: NSObject, MTKViewDelegate {

    // Controllers
    private let particleController = ParticleController()
    private let emitter: Emitter

    // Context
    private let device: MTLDevice
    private let commandQueue: MTLCommandQueue
    private let pipelineState: MTLRenderPipelineState

    // Buffers
    private let vertexBuffer: MTLBuffer
    private let indexBuffer: MTLBuffer
    private let uniformBuffer: MTLBuffer
    private let instanceBuffer: MTLBuffer

    // Textures
    private let texture: MTLTexture

    // CPU instance staging (rebuilt each frame for now)
    private var instances: [InstanceData] = []

    // Timing
    private var lastTime: Double = 0.0
    private var elapsedTime: Float = 0.0

    private let vertices: [Vertex] = [
        Vertex(position: [-0.5,  0.5], color: [1, 0, 0, 1], uv: [0, 0]), // tl
        Vertex(position: [ 0.5,  0.5], color: [0, 1, 0, 1], uv: [1, 0]), // tr
        Vertex(position: [-0.5, -0.5], color: [0, 0, 1, 1], uv: [0, 1]), // bl
        Vertex(position: [ 0.5, -0.5], color: [1, 1, 0, 1], uv: [1, 1])  // br
    ]

    private let indices: [UInt16] = [
        0, 1, 2,
        2, 1, 3
    ]

    init(mtkView: MTKView) {
        guard let device = MTLCreateSystemDefaultDevice() else {
            fatalError("Metal is not supported on this device.")
        }
        self.device = device
        mtkView.device = device

        self.emitter = Emitter(spawnRate: 40, maxParticles: 500)

        // Texture
        let textureLoader = MTKTextureLoader(device: device)
        guard let url = Bundle.main.url(forResource: "fuzzy", withExtension: "png") else {
            fatalError("Missing fuzzy.png in app bundle.")
        }
        do {
            self.texture = try textureLoader.newTexture(URL: url, options: [
                MTKTextureLoader.Option.SRGB: false
            ])
        } catch {
            fatalError("Error loading particle texture: \(error)")
        }

        // Command queue
        guard let commandQueue = device.makeCommandQueue() else {
            fatalError("Failed to create Metal command queue.")
        }
        self.commandQueue = commandQueue

        // Buffers
        self.vertexBuffer = device.makeBuffer(
            bytes: vertices,
            length: MemoryLayout<Vertex>.stride * vertices.count,
            options: .storageModeShared
        )!

        self.indexBuffer = device.makeBuffer(
            bytes: indices,
            length: MemoryLayout<UInt16>.stride * indices.count,
            options: .storageModeShared
        )!

        self.uniformBuffer = device.makeBuffer(
            length: MemoryLayout<Uniforms>.stride,
            options: .storageModeShared
        )!

        self.instanceBuffer = device.makeBuffer(
            length: MemoryLayout<InstanceData>.stride * emitter.userMaxParticles,
            options: .storageModeShared
        )!

        // Pipeline
        guard let library = device.makeDefaultLibrary() else {
            fatalError("Failed to load default Metal library (Shaders.metal).")
        }

        let pipelineDescriptor = MTLRenderPipelineDescriptor()
        pipelineDescriptor.vertexFunction = library.makeFunction(name: "vertex_main")
        pipelineDescriptor.fragmentFunction = library.makeFunction(name: "fragment_main")

        let attachment = pipelineDescriptor.colorAttachments[0]!
        attachment.pixelFormat = mtkView.colorPixelFormat

        // Alpha blending (straight alpha)
        attachment.isBlendingEnabled = true
        attachment.rgbBlendOperation = .add
        attachment.alphaBlendOperation = .add
        attachment.sourceRGBBlendFactor = .sourceAlpha
        attachment.sourceAlphaBlendFactor = .sourceAlpha
        attachment.destinationRGBBlendFactor = .oneMinusSourceAlpha
        attachment.destinationAlphaBlendFactor = .oneMinusSourceAlpha

        do {
            self.pipelineState = try device.makeRenderPipelineState(descriptor: pipelineDescriptor)
        } catch {
            fatalError("Failed to create pipeline state: \(error)")
        }

        super.init()

        updateUniforms(for: mtkView.drawableSize)
        mtkView.delegate = self
    }

    func mtkView(_ view: MTKView, drawableSizeWillChange size: CGSize) {
        updateUniforms(for: size)
    }

    func draw(in view: MTKView) {
        // Timing
        let currentTime = CACurrentMediaTime()
        let deltaTime: Float
        if lastTime == 0 {
            deltaTime = 0
        } else {
            deltaTime = Float(currentTime - lastTime)
        }
        lastTime = currentTime
        elapsedTime += deltaTime

        guard
            let drawable = view.currentDrawable,
            let descriptor = view.currentRenderPassDescriptor,
            let commandBuffer = commandQueue.makeCommandBuffer(),
            let encoder = commandBuffer.makeRenderCommandEncoder(descriptor: descriptor)
        else {
            return
        }

        // --- Simulation ---
        emitter.emit(deltaTime: deltaTime, into: particleController)
        particleController.update(deltaTime: deltaTime, elapsedTime: elapsedTime)

        // --- Build instance data (CPU) ---
        let particles = particleController.particles
        instances = particles.map {
            InstanceData(
                position: $0.position,
                size: 20,
                color: SIMD4<Float>(1, 1, 1, 1)
            )
        }

        // --- Upload instance data (GPU) ---
        let instanceCount = instances.count
        if instanceCount > 0 {
            let ptr = instanceBuffer.contents()
                .bindMemory(to: InstanceData.self, capacity: emitter.userMaxParticles)
            ptr.update(from: instances, count: instanceCount)
        }

        // --- Encode draw ---
        encoder.setRenderPipelineState(pipelineState)
        encoder.setFragmentTexture(texture, index: 0)

        encoder.setVertexBuffer(vertexBuffer, offset: 0, index: 0)
        encoder.setVertexBuffer(uniformBuffer, offset: 0, index: 1)
        encoder.setVertexBuffer(instanceBuffer, offset: 0, index: 2)

        if instanceCount > 0 {
            encoder.drawIndexedPrimitives(
                type: .triangle,
                indexCount: indices.count,
                indexType: .uint16,
                indexBuffer: indexBuffer,
                indexBufferOffset: 0,
                instanceCount: instanceCount
            )
        }

        encoder.endEncoding()
        commandBuffer.present(drawable)
        commandBuffer.commit()
    }

    private static func makeOrthoProjection(width: Float, height: Float) -> simd_float4x4 {
        let left: Float   = -width / 2
        let right: Float  =  width / 2
        let bottom: Float = -height / 2
        let top: Float    =  height / 2
        let near: Float   = -1
        let far: Float    =  1

        return simd_float4x4(columns: (
            SIMD4<Float>(2 / (right - left), 0, 0, 0),
            SIMD4<Float>(0, 2 / (top - bottom), 0, 0),
            SIMD4<Float>(0, 0, -2 / (far - near), 0),
            SIMD4<Float>(
                -(right + left) / (right - left),
                -(top + bottom) / (top - bottom),
                -(far + near) / (far - near),
                1
            )
        ))
    }

    private func updateUniforms(for size: CGSize) {
        let w = max(Float(size.width), 1)
        let h = max(Float(size.height), 1)

        let projection = Renderer.makeOrthoProjection(width: w, height: h)
        var uniforms = Uniforms(projectionMatrix: projection)

        memcpy(uniformBuffer.contents(), &uniforms, MemoryLayout<Uniforms>.stride)
    }
}
