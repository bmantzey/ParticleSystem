//
//  Renderer.swift
//  ParticleEditor
//
//  Created by Brandon Mantzey on 12/11/25.
//

import MetalKit

final class Renderer: NSObject, MTKViewDelegate {
    
    private let device: MTLDevice
    private let commandQueue: MTLCommandQueue
    private var pipelineState: MTLRenderPipelineState!
    private var vertexBuffer: MTLBuffer!
    
    private let vertexData: [Vertex] = [
        Vertex(position: [ 0.0,  0.5], color: [1, 0, 0, 1]),
        Vertex(position: [-0.5, -0.5], color: [0, 1, 0, 1]),
        Vertex(position: [ 0.5, -0.5], color: [0, 0, 1, 1]),
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
        
        let length = MemoryLayout<Vertex>.stride * vertexData.count
        vertexBuffer = device.makeBuffer(bytes: vertexData,
                                         length: length,
                                         options: [])
        
        // Load default library, which contains Shaders.metal
        let library = device.makeDefaultLibrary()
        
        // Create a pipeline descriptor
        let pipelineDescriptor = MTLRenderPipelineDescriptor()
        pipelineDescriptor.vertexFunction = library?.makeFunction(name: "vertex_main")
        pipelineDescriptor.fragmentFunction = library?.makeFunction(name: "fragment_main")
        pipelineDescriptor.colorAttachments[0].pixelFormat = mtkView.colorPixelFormat
        
        // Compile pipeline
        do {
            pipelineState = try device.makeRenderPipelineState(descriptor: pipelineDescriptor)
        } catch {
            fatalError("Failed to create pipeline state: \(error)")
        }
        
        super.init()
        
        mtkView.delegate = self
    }
    
    func mtkView(_ view: MTKView, drawableSizeWillChange size: CGSize) {
        // TODO:
    }
    
    func draw(in view: MTKView) {
        guard let drawable = view.currentDrawable else { return }
        guard let descriptor = view.currentRenderPassDescriptor else { return }
        guard let commandBuffer = commandQueue.makeCommandBuffer() else { return }
        guard let encoder = commandBuffer.makeRenderCommandEncoder(descriptor: descriptor) else { return }
        
        encoder.setVertexBuffer(vertexBuffer, offset: 0, index: 0)
        encoder.setRenderPipelineState(pipelineState)
        encoder.drawPrimitives(type: .triangle, vertexStart: 0, vertexCount: 3)
        
        encoder.endEncoding()
        
        commandBuffer.present(drawable)
        commandBuffer.commit()
    }
    
    
}
