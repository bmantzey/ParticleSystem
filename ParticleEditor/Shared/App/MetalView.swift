//
//  MetalView.swift
//  ParticleEditor
//
//  Created by Brandon Mantzey on 12/10/25.
//

import SwiftUI
import MetalKit

struct MetalView: View {
    var body: some View {
        MetalViewRepresentable()
    }
}

#if os(iOS)

struct MetalViewRepresentable: UIViewRepresentable {
    
    class Coordinator {
        var renderer: Renderer?
        
        func attach(to mtkView: MTKView) {
            renderer = Renderer(mtkView: mtkView)
        }
    }
    
    func makeCoordinator() -> Coordinator {
        Coordinator()
    }

    func makeUIView(context: Context) -> MTKView {
        let mtkView = MTKView()
        context.coordinator.attach(to: mtkView)
        return mtkView
    }

    func updateUIView(_ uiView: MTKView, context: Context) {
        // nothing yet
    }
}

#elseif os(macOS)

struct MetalViewRepresentable: NSViewRepresentable {
    
    class Coordinator {
        var renderer: Renderer?
        
        func attach(to mtkView: MTKView) {
            renderer = Renderer(mtkView: mtkView)
        }
    }
    
    func makeCoordinator() -> Coordinator {
        Coordinator()
    }
    
    func makeNSView(context: Context) -> MTKView {
        let mtkView = MTKView()
        context.coordinator.attach(to: mtkView)
        return mtkView
    }

    func updateNSView(_ nsView: MTKView, context: Context) {
        // nothing yet
    }
}

#endif
