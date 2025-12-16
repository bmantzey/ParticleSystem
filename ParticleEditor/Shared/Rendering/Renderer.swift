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
    private var particleController: ParticleController!
    
    // Context
    private let device: MTLDevice
    private let commandQueue: MTLCommandQueue
    private var pipelineState: MTLRenderPipelineState!
    
    // Buffers
    private var vertexBuffer: MTLBuffer!
    private var indexBuffer: MTLBuffer!
    private var uniformBuffer: MTLBuffer!
    private var instanceBuffer: MTLBuffer!
    
    // Textures
    private var texture: MTLTexture!
    
    // Instance Data
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
        // Create the device.
        guard let device = MTLCreateSystemDefaultDevice() else {
            fatalError("Metal is not supported on this device.")
        }
        self.device = device
        mtkView.device = device
        
        let initialParticleCount = 50
        
        let initialParticles = (0..<initialParticleCount).map { i in
            Particle(
                position: SIMD2<Float>(
                    Float.random(in: -200...200),
                    Float.random(in: -100...100)
                ),
                velocity: SIMD2<Float>(0, Float.random(in: 10...30)),
                age: 0,
                lifetime: Float.random(in: 2.0...5.0)
            )
        }
        
        particleController = ParticleController(particles: initialParticles)
        
        instances = initialParticles.map {
            InstanceData(
                position: $0.position,
                size: 20,
                color: SIMD4<Float>(1, 1, 1, 1)
            )
        }
                
        instanceBuffer = device.makeBuffer(
            bytes: instances,
            length: MemoryLayout<InstanceData>.stride * instances.count,
            options: []
        )
        
        // Load the texture
        let textureLoader = MTKTextureLoader(device: device)
        let url = Bundle.main.url(forResource: "fuzzy", withExtension: "png")!
        do {
            texture = try textureLoader.newTexture(URL: url, options: [
                MTKTextureLoader.Option.SRGB: false
            ])
        } catch {
            fatalError("Error loading particle texture.")
        }
        
        // Make the command queue.
        guard let commandQueue = device.makeCommandQueue() else {
            fatalError("Failed to create Metal command queue.")
        }
        self.commandQueue = commandQueue
        
        // Buffers
        let length = MemoryLayout<Vertex>.stride * vertices.count
        vertexBuffer = device.makeBuffer(
            bytes: vertices,
            length: length,
            options: []
        )
        indexBuffer = device.makeBuffer(
            bytes: indices,
            length: MemoryLayout<UInt16>.stride * indices.count,
            options: []
        )
       
        // Load default library, which contains Shaders.metal
        let library = device.makeDefaultLibrary()
        
        // Create a pipeline descriptor
        let pipelineDescriptor = MTLRenderPipelineDescriptor()
        pipelineDescriptor.vertexFunction = library?.makeFunction(name: "vertex_main")
        pipelineDescriptor.fragmentFunction = library?.makeFunction(name: "fragment_main")
        guard let colorAttachment = pipelineDescriptor.colorAttachments[0] else {
            fatalError("Missing color attachment 0 on pipeline descriptor.")
        }
        
        colorAttachment.pixelFormat = mtkView.colorPixelFormat
        // Enable standard alpha blending (straight alpha)
        colorAttachment.isBlendingEnabled = true
        colorAttachment.rgbBlendOperation = .add
        colorAttachment.alphaBlendOperation = .add
        colorAttachment.sourceRGBBlendFactor = .sourceAlpha
        colorAttachment.sourceAlphaBlendFactor = .sourceAlpha
        colorAttachment.destinationRGBBlendFactor = .oneMinusSourceAlpha
        colorAttachment.destinationAlphaBlendFactor = .oneMinusSourceAlpha
        
        
        // Compile pipeline
        do {
            pipelineState = try device.makeRenderPipelineState(descriptor: pipelineDescriptor)
        } catch {
            fatalError("Failed to create pipeline state: \(error)")
        }
        
        super.init()
        
        updateUniforms(for: mtkView.drawableSize)
        mtkView.delegate = self

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
        
        if uniformBuffer == nil {
            uniformBuffer = device.makeBuffer(length: MemoryLayout<Uniforms>.stride, options: [])
        }
        memcpy(uniformBuffer.contents(), &uniforms, MemoryLayout<Uniforms>.stride)
    }
    
    func mtkView(_ view: MTKView, drawableSizeWillChange size: CGSize) {
        updateUniforms(for: size)
    }
    
    func draw(in view: MTKView) {
        let currentTime = CACurrentMediaTime()
        let deltaTime: Float
        if lastTime == 0 {
            deltaTime = 0
        } else {
            deltaTime = Float(currentTime - lastTime)
        }
        elapsedTime += deltaTime
        
        guard let drawable = view.currentDrawable else { return }
        guard let descriptor = view.currentRenderPassDescriptor else { return }
        guard let commandBuffer = commandQueue.makeCommandBuffer() else { return }
        guard let encoder = commandBuffer.makeRenderCommandEncoder(descriptor: descriptor) else { return
        }
        
        // Render state
        particleController.update(deltaTime: deltaTime, elapsedTime: elapsedTime)
        let particles = particleController.particles
        instances = particles.map {
            InstanceData(
                position: $0.position,
                size: 20,
                color: SIMD4<Float>(1, 1, 1, 1)
            )
        }
        
//        for i in particles.indices {
//            instances[i].position = particles[i].position
//        }

        memcpy(
            instanceBuffer.contents(),
            instances,
            MemoryLayout<InstanceData>.stride * instances.count
        )
        
        encoder.setFragmentTexture(texture, index: 0)
        encoder.setVertexBuffer(vertexBuffer, offset: 0, index: 0)
        if uniformBuffer == nil {
            updateUniforms(for: view.drawableSize)
        }
        encoder.setVertexBuffer(uniformBuffer, offset: 0, index: 1)
        encoder.setRenderPipelineState(pipelineState)
        encoder.setVertexBuffer(instanceBuffer, offset: 0, index: 2)
        if !instances.isEmpty {
            encoder.drawIndexedPrimitives(
                type: .triangle,
                indexCount: indices.count,
                indexType: .uint16,
                indexBuffer: indexBuffer,
                indexBufferOffset: 0,
                instanceCount: instances.count
            )
        }
        
        encoder.endEncoding()
        
        commandBuffer.present(drawable)
        commandBuffer.commit()
        
        lastTime = currentTime

    }
    
    
}

