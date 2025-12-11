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
    float4 color;
};

// Vertex shader
vertex VertexOut vertex_main(uint vertexID [[vertex_id]]) {
    // Temporary triangle for proof
    float2 positions[3] = {
        float2( 0.0, 0.5), // top
        float2( -0.5, -0.5), // bottom left
        float2( 0.5, -0.5), // bottom right
    };
    
    float4 colors[3] = {
        float4(1,0,0,1), // red
        float4(0,1,0,1), // green
        float4(0,0,1,1), // blue
    };
    
    VertexOut out;
    out.position = float4(positions[vertexID], 0.0, 1.0);
    out.color = colors[vertexID];
    return out;
}

// Fragment shader (solid white)
fragment float4 fragment_main(VertexOut in [[stage_in]]) {
    return in.color;
}
