//
//  ParticleController.swift
//  ParticleEditor
//
//  Created by Brandon Mantzey on 12/16/25.
//
//  https://bmantzey.dev
//

import simd

final class ParticleController {
    private(set) var particles: [Particle] = []
    
    func update(deltaTime: Float, elapsedTime: Float) {
        // Update
        let strength: Float = 50
        let speed: Float = 2

        for i in particles.indices {
            particles[i].age += deltaTime
            particles[i].velocity.y = sin(elapsedTime * speed) * strength
            particles[i].position += particles[i].velocity * deltaTime
        }
        
        // Remove dead particles
        particles.removeAll { particle in
            particle.age >= particle.lifespan
        }
    }
    
    func addParticle(_ particle: Particle) {
        particles.append(particle)
    }
}
