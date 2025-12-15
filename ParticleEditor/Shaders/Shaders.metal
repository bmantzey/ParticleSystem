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

struct InstanceData {
    float2 position;
    float size;
    float4 color;
};

// Vertex shader
vertex VertexOut vertex_main(
                             const device Vertex* vertices [[buffer(0)]],
                             constant Uniforms& uniforms [[buffer(1)]],
                             const device InstanceData* inst [[buffer(2)]],
                             uint vertexID [[vertex_id]],
                             uint instanceID [[instance_id]]
                             ) {
    VertexOut out;
    const Vertex v = vertices[vertexID];
    const InstanceData data = inst[instanceID];
    
    float2 local = vertices[vertexID].position * data.size;
    float2 world = local + data.position;
    
    out.position = uniforms.projectionMatrix * float4(world, 0.0, 1.0);
    out.color = data.color;
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
