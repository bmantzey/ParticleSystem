//
//  Renderer.swift
//  ParticleEditor
//
//  Created by Brandon Mantzey on 12/11/25.
//

import MetalKit
import simd

struct Uniforms {
    var projectionMatrix: simd_float4x4
}

final class Renderer: NSObject, MTKViewDelegate {
    
    private let device: MTLDevice
    private let commandQueue: MTLCommandQueue
    private var pipelineState: MTLRenderPipelineState!
    private var vertexBuffer: MTLBuffer!
    private var indexBuffer: MTLBuffer!
    private var uniformBuffer: MTLBuffer!
    
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
        
        guard let commandQueue = device.makeCommandQueue() else {
            fatalError("Failed to create Metal command queue.")
        }
        self.commandQueue = commandQueue
        
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
        let aspect = width / height

        let left: Float   = -aspect
        let right: Float  =  aspect
        let bottom: Float = -1
        let top: Float    =  1
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
        guard let drawable = view.currentDrawable else { return }
        guard let descriptor = view.currentRenderPassDescriptor else { return }
        guard let commandBuffer = commandQueue.makeCommandBuffer() else { return }
        guard let encoder = commandBuffer.makeRenderCommandEncoder(descriptor: descriptor) else { return }
        
        
        encoder.setVertexBuffer(vertexBuffer, offset: 0, index: 0)
        if uniformBuffer == nil {
            updateUniforms(for: view.drawableSize)
        }
        encoder.setVertexBuffer(uniformBuffer, offset: 0, index: 1)
        encoder.setRenderPipelineState(pipelineState)
        encoder.drawIndexedPrimitives(
            type: .triangle,
            indexCount: 6,
            indexType: .uint16,
            indexBuffer: indexBuffer,
            indexBufferOffset: 0
        )
        
        encoder.endEncoding()
        
        commandBuffer.present(drawable)
        commandBuffer.commit()
    }
    
    
}
