//
//  Emitter.swift
//  ParticleEditor
//
//  Created by Brandon Mantzey on 12/10/25.
//
//  https://bmantzey.dev
//
//  • decides when particles are born
//  • decides how many particles to spawn this frame
//  • creates particles with initial state
//  • does not update particles
//  • does not render anything
//

import simd

/* Each Frame:
 
 accumulator += deltaTime * spawnRate

 while accumulator >= 1:
     spawn particle
     accumulator -= 1

 */

final class Emitter {
    
    // Configuration
    let spawnRate: Float // particles per second (pps)
    let maxParticles: Int
    
    // Internal state
    private var accumulator: Float = 0
    
    init(spawnRate: Float, maxParticles: Int) {
        self.spawnRate = spawnRate
        self.maxParticles = maxParticles
    }
    
    func emit(deltaTime: Float, into controller: ParticleController) {
        accumulator += deltaTime * spawnRate
        
        while accumulator >= 1 {
            if controller.particles.count >= maxParticles {
                break
            }
            
            controller.addParticle(makeParticle())
            accumulator += 1
        }
    }
    
    private func makeParticle() -> Particle {
        Particle(
            position: SIMD2<Float>(0, 0),
            velocity: SIMD2<Float>(
                Float.random(in: -10...10),
                Float.random(in: 20...60)
            ),
            age: 0,
            lifetime: Float.random(in: 2.0...5.0)
        )
    }
}
