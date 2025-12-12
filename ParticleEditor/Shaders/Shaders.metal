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
    float2 uv;
};

// Vertex structure
struct Vertex {
    float2 position;
    float4 color;
    float2 uv;
};

// Vertex shader
vertex VertexOut vertex_main(
                             const device Vertex* vertices [[buffer(0)]],
                             uint vid [[vertex_id]]
                             ) {
    Vertex v = vertices[vid];
    
    VertexOut out;
    out.position = float4(v.position, 0.0, 1.0);
    out.color = v.color;
    out.uv = v.uv;
    return out;
}

// Fragment shader (solid white)
fragment float4 fragment_main(VertexOut in [[stage_in]]) {
    float2 centeredUV = in.uv - float2(0.5, 0.5);
    float dist = length(centeredUV);
    float alpha = smoothstep(0.5, 0.45, dist);
    
    return float4(1.0, 1.0, 1.0, alpha);
}
