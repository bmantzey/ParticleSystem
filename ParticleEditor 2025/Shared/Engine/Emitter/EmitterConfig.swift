//
//  EmitterConfig.swift
//  ParticleEditor
//
//  Created by Brandon Mantzey on 12/18/25.
//
//  https://bmantzey.dev
//

import simd
import CoreGraphics

public struct EmitterConfig {
    var emitterPosition: CGRect = .zero
    var spawnRate: Float // particles per second (pps)
    
    // Initial Particle Properties for initial state only - only set these once.
    var initialVelocity: SIMD2<Float> = .zero // not moving
    var initialSize: Float = 1.0 // Full scale
    var startColor: SIMD4<Float> = .one // starts white
    var endColor: SIMD4<Float> = .one // ends white
    var lifespan: Float = 1.0 // seconds
    


}
