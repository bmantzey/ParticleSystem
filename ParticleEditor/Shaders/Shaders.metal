//
//  Shaders.metal
//  ParticleEditor
//
//  Created by Brandon Mantzey on 12/11/25.
//

#include <metal_stdlib>
using namespace metal;

// Vertex structure
struct VertexOut {
    float4 position [[position]];
};

// Vertex shader
vertex VertexOut vertex_main(uint vertexID [[vertex_id]]) {
    VertexOut out;
    out.position = float4(0.0, 0.0, 0.0, 1.0);
    return out;
}

// Fragment shader (solid white)
fragment float4 fragment_main() {
    return float4(1.0, 1.0, 1.0, 1.0);
}
