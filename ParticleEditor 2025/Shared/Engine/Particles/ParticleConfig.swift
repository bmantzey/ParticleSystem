//
//  ParticleConfig.swift
//  ParticleEditor
//
//  Created by Brandon Mantzey on 12/18/25.
//
//  https://bmantzey.dev
//

import simd

struct ParticleConfig {
    let initialVelocity: SIMD2<Float>
    let lifespan: Float
    
    let startColor: SIMD4<Float>
    let endColor: SIMD4<Float>
    
    let startSize: Float
    let endSize: Float
    let startRotation: Float
    let endRotation: Float
    
    static func defaultState() -> ParticleConfig {
        ParticleConfig(
            initialVelocity: .zero,
            lifespan: 10,
            startColor: .one,
            endColor: .zero,
            startSize: 1,
            endSize: 1,
            startRotation: 0,
            endRotation: 6.283185307179586
        )
    }
    // Later, can add angularVelocity
}
