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

struct Uniforms {
    float4x4 projectionMatrix;
};

// Vertex shader
vertex VertexOut vertex_main(
                             const device Vertex* vertices [[buffer(0)]],
                             constant Uniforms& uniforms [[buffer(1)]],
                             uint vid [[vertex_id]]
                             ) {
    Vertex v = vertices[vid];
    VertexOut out;
    
    out.position = uniforms.projectionMatrix * float4(v.position, 0.0, 1.0);
    out.color = v.color;
    out.uv = v.uv;
    return out;
}

fragment float4 fragment_main(VertexOut in [[stage_in]],
                              texture2d<float> tex [[texture(0)]]) {
    float2 centeredUV = in.uv * 2.0 - 1.0;
    float dist = length(centeredUV);
    
    // Soft circle mask
    float circle = 1.0 - smoothstep(0.45, 0.5, dist);
    
    // Sample texture
    constexpr sampler s(address::clamp_to_edge,
                        filter::linear);
    float4 texColor = tex.sample(s, in.uv);

    // Combine
    float alpha = texColor.a * circle;
    float3 color = texColor.rgb * in.color.rgb;

    return float4(color, alpha);
}
