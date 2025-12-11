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
        
        super.init()
        
        mtkView.delegate = self
    }
    
    func mtkView(_ view: MTKView, drawableSizeWillChange size: CGSize) {
        
    }
    
    func draw(in view: MTKView) {
        guard let drawable = view.currentDrawable else { return }
        guard let descriptor = view.currentRenderPassDescriptor else { return }
        guard let commandBuffer = commandQueue.makeCommandBuffer() else { return }
        guard let encoder = commandBuffer.makeRenderCommandEncoder(descriptor: descriptor) else { return }
        
        encoder.endEncoding()
        commandBuffer.present(drawable)
        commandBuffer.commit()
    }
    
    
}
