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
        
    }
    
    func makeCoordinator() -> Coordinator {
        Coordinator()
    }

    func makeUIView(context: Context) -> MTKView {
        MTKView()
    }

    func updateUIView(_ uiView: MTKView, context: Context) {
        // nothing yet
    }
}

#elseif os(macOS)

struct MetalViewRepresentable: NSViewRepresentable {
    
    class Coordinator {
        
    }
    
    func makeCoordinator() -> Coordinator {
        
    }
    
    func makeNSView(context: Context) -> MTKView {
        MTKView()
    }

    func updateNSView(_ nsView: MTKView, context: Context) {
        // nothing yet
    }
}

#endif
