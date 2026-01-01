//
//  Emitter.swift
//  ParticleEditor
//
//  Created by Brandon Mantzey on 12/10/25.
//
//  https://bmantzey.dev
//
// The Emitter should:
//
// • Own how many particles may exist
// • Own when particles are born
// • Own where particles are born
// • Own initial state only
// • Own reuse / dead pool
// • Own spawn rate smoothing
//
// The Emitter should NOT:
//
// • Update particles per frame
// • Apply forces
// • Care about rendering or buffers
// • Know anything about GPU layout
//

import simd
import CoreGraphics

final class Emitter {
    static let maxPartlceCap = 50000
    
    private var emitterConfig: EmitterConfig
    private var particleStartState: ParticleConfig = ParticleConfig.defaultState()
    
    // Accumulator makes particles spawn time based not frame based, to prevent surging.
    private var accumulator: Float = 0
    
    // Particle pool (memory allocation optimization)
    private var userMaxParticles = 100
    private var particlePool: [Particle] = []
    private var currentAliveCount: Int = 0
    
    init(emitterConfig: EmitterConfig) {
        self.emitterConfig = emitterConfig
        self.ensureParticlePoolCapacity(to: self.userMaxParticles)
    }
    
    internal func applyNewEmitterConfig(_ newConfig: EmitterConfig) {
        self.emitterConfig = newConfig
    }
    
    internal func applyNewParticleStartState(_ newState: ParticleConfig) {
        self.particleStartState = newState
    }
    
    internal func applyNewUserMaxParticles(_ newMax: Int) {
        self.userMaxParticles = newMax
        ensureParticlePoolCapacity(to: self.userMaxParticles)
    }
    
    private func ensureParticlePoolCapacity(to size: Int) {
        let resizeTo = min(size, Emitter.maxPartlceCap)
        let howManyToAdd = max(0, resizeTo - (currentAliveCount + particlePool.count))
        
        for _ in 0..<howManyToAdd {
            particlePool.append(Particle())
        }
    }
    
    /// NOTE: This is called every frame.
    internal func emit(deltaTime: Float, into controller: ParticleController) {
        accumulator += deltaTime * emitterConfig.spawnRate
        
        while accumulator >= 1 {
            if controller.particles.count >= userMaxParticles {
                break
            }
            
            controller.addParticle(makeParticle())
            accumulator -= 1
            currentAliveCount += 1
        }
    }
    
    internal func killParticle(deadParticle: Particle) {
        currentAliveCount -= 1
        particlePool.append(deadParticle)
    }
    
    private func freshParticleStartPosition() -> SIMD2<Float> {
        // Random position on the x and the y within the bounds of the Emitter.
        let emitterPosition = emitterConfig.emitterPosition
        let x = Float.random(in: Float(emitterPosition.minX)...Float(emitterPosition.maxX))
        let y = Float.random(in: Float(emitterPosition.minY)...Float(emitterPosition.maxY))
        return SIMD2<Float>(x, y)
    }
    
    private func makeParticle() -> Particle {
        var freshParticle: Particle
        let freshParticlePosition = freshParticleStartPosition()
        if !particlePool.isEmpty {
            // LIFO is an important optimization for pool logic.
            freshParticle = particlePool.removeLast()
            freshParticle.reset(from: particleStartState, initialPosition: freshParticlePosition)
        } else {
            freshParticle = Particle.makeParticle(from: particleStartState, initialPosition: freshParticlePosition)
        }
        
        return freshParticle
    }
}
