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

// TODO: Particle reuse. A dead pool.  Create user_max_particles first, allocate them all, and mark them as 'dead' at creation time.  Part of spawning a new particle would be marking it as alive and setting its configuration values.

final class Emitter {
    
    // Configuration
    let spawnRate: Float // particles per second (pps)
    var userMaxParticles = 100
    
    // Accumulator makes particles spawn time based not frame based, to prevent surging.
    private var accumulator: Float = 0
    
    // TODO: This init should take a config file.
    init(spawnRate: Float, maxParticles: Int) {
        self.spawnRate = spawnRate
        self.userMaxParticles = maxParticles
    }
    
    // TODO: We need an update call for when a new set of emitter parameters has been set by the user from the UI.
    
    func emit(deltaTime: Float, into controller: ParticleController) {
        accumulator += deltaTime * spawnRate
        
        while accumulator >= 1 {
            if controller.particles.count >= userMaxParticles {
                break
            }
            
            controller.addParticle(makeParticle())
            accumulator += 1
        }
    }
    
    private func makeParticle() -> Particle {
        // TODO: Actual particle configuration based on a config file which will be received by the controls in the UI.  Needs to be comprehensive, reflect the UI, and not have these temporary random numbers in it.
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
