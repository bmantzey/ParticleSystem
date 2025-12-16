//
//  ParticleController.swift
//  ParticleEditor
//
//  Created by Brandon Mantzey on 12/16/25.
//
//  https://bmantzey.dev

import simd

final class ParticleController {
    private(set) var particles: [Particle] = []
    
    init(particles: [Particle]) {
        self.particles = particles
    }
    
    func update(deltaTime: Float, elapsedTime: Float) {
        let amplitude: Float = 25
        let speed: Float = 2.0
        
        for i in particles.indices {
            particles[i].position.y = sin(elapsedTime * speed) * amplitude
        }
    }
}
