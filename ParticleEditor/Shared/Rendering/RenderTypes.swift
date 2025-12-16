//
//  RenderTypes.swift
//  ParticleEditor
//
//  Created by Brandon Mantzey on 12/15/25.
//
//  https://bmantzey.dev

import MetalKit
import simd

struct Vertex {
    var position: SIMD2<Float>
    var color: SIMD4<Float>
    var uv: SIMD2<Float>
}

struct Uniforms {
    var projectionMatrix: simd_float4x4
}

struct InstanceData {
    var position: SIMD2<Float>
    var size: Float
    var color: SIMD4<Float>
}
