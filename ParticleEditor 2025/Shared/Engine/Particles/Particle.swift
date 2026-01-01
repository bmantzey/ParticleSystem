//
//  Particle.swift
//  ParticleEditor
//
//  Created by Brandon Mantzey on 12/16/25.
//
//  https://bmantzey.dev
//
//  The idea of a "Particle": Birth -> Life -> Death

import simd

struct Particle {
    // Spatial properties
    var position: SIMD2<Float> = .zero
    var velocity: SIMD2<Float> = .zero
    
    // Lifetime properties
    var age: Float = 0.0
    var lifespan: Float = 0.0
    
    // Visual properties
    var color: SIMD4<Float> = .one
    var size: Float = 1.0
    var rotation: Float = 0.0
    
    static func makeParticle(from config: ParticleConfig, initialPosition: SIMD2<Float>) -> Particle {
        var newParticle = Particle()
        newParticle.reset(from: config, initialPosition: initialPosition)
        return newParticle
    }
    
    mutating func reset(from config: ParticleConfig, initialPosition: SIMD2<Float>) {
        position = initialPosition
        velocity = config.initialVelocity
        age = 0.0
        lifespan = config.lifespan
        color = config.startColor
        size = config.startSize
        rotation = config.startRotation        
    }
    
    mutating func reset() {
        position = .zero
        velocity = .zero
        age = 0.0
        lifespan = 0.0
        color = .one
        size = 1.0
        rotation = 0.0
    }
}
