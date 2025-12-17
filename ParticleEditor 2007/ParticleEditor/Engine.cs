using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Timers;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace ParticleEditor
{
	/// <summary>
	///	File:		"Engine.cs"
	///	Author:		Brandon Mantzey
	///	Purpose:	Contains all data used for the emission of particles.
	///				Contains all data used for each individual particle.
	/// </summary>
	public class Engine
	{
		// Not doing any drawing in this class.  Only including DirectX references for the data types.
		// This class is used to store and update the particle and emitter information.
		public delegate bool UpdateParticle(ref Particle p);
		public delegate void AddParticle(ref Particle p);

		/// <summary>
		/// Structure:	Particle
		/// Author:		Brandon Mantzey
		/// Purpose:	Contains all data used by each particle that is updated and rendered.
		/// </summary>
		/// <returns>Normalized representation of the direction passed in.</returns>

		public struct Particle
		{
			/// <summary>
			/// Current particle position.  Initialize to Emitter.position
			/// </summary>
			public PointF position;
			/// <summary>
			/// Current speed of each individual particle.
			/// </summary>
			public Vector2 currentVelocity;
			/// <summary>
			/// A flag used to determine if this particle should be killed and recreated.
			/// </summary>
			public bool isAlive;
			/// <summary>
			/// Initialized to Emitter.startColor.  Linearly interpolated from startColor to endColor based on elapsedTime/lifeTime.
			/// </summary>
			public ColorValue currentColor;
			/// <summary>
			/// Linearly interpolated from startSize to endSize based on elapsedTime/lifeTime.
			/// </summary>
			public float currentSize;	// Updated the same as color.
			/// <summary>
			/// Needed for each particle in order to update the size and color.
			/// </summary>
			public double elapsedTime;
			/// <summary>
			/// The length, in time, that the particle will be alive.
			/// </summary>
			public double lifeTime;
		}

		public struct Emitter
		{
			/// <summary>
			/// Apply this to each particle every update - time based.
			/// </summary>
			public Vector2 acceleration;

			/// <summary>
			/// Begin scale of each particle.
			/// </summary>
			public float beginSize;

			/// <summary>
			/// Direction will multiply by its speed every update.
			/// </summary>
			public float directionBegin;

			/// <summary>
			/// In order to change position.
			/// </summary>
			public float directionEnd;

			/// <summary>
			/// End color of each particle.
			/// </summary>
			public ColorValue endColor;

			/// <summary>
			/// End scale of each particle.
			/// </summary>
			public float endSize;

			/// <summary>
			/// Maximum lifetime of the particle.  Range of lifetime is important to prevent "clumping".
			/// </summary>
			public double maxLifetime;

			/// <summary>
			/// Minimum lifetime of the particle.  Range of lifetime is important to prevent "clumping".
			/// </summary>
			public double minLifetime;

			/// <summary>
			/// Dynamically changes the size of the particle List and adds the new particles to the List.
			/// </summary>
			public int numParticles;

			/// <summary>
			/// Use this to set the initial position of the particle when created
			/// </summary>
			public Point position;

			/// <summary>
			/// Size of the emitter base.
			/// </summary>
			public Size size;

			/// <summary>
			/// This is the starting speed for all particles.
			/// </summary>
			public double speed;

			/// <summary>
			/// Start color of each particle.
			/// </summary>
			public ColorValue startColor;
		}
		/// <summary>
		/// All particles are contained in this list.
		/// </summary>
		public List<Particle> particles;

		/// <summary>
		/// Constructor for the Engine class.
		/// </summary>
		public Engine()
		{
			particles = new List<Particle>();
			particles.Capacity = emitter.numParticles + 1;

			XMLIO = new XmlSerializer(typeof(Emitter));
		}
		// Structure Definitions
		// Public members
		public Emitter emitter = new Emitter();
		/// <summary>
		/// Calls the update function that updates the particle data.  This is a delegate (function pointer).
		/// </summary>
		public UpdateParticle updateFunc;
		/// <summary>
		/// Calls the add function that adds a particle to the list.  This is a delegate (function pointer).
		/// </summary>
		public AddParticle addFunc;
		/// <summary>
		/// Serialization member.
		/// </summary>
		public XmlSerializer XMLIO;

		// Public methods
		/// <summary>
		/// This function is called every frame.  It checks to see if particles need to be added/removed from 
		/// the list and updates the particles every frame.
		/// </summary>
		public void update()
		{
			if (AddParticle.ReferenceEquals(this, null) == true)
				return;
			while (emitter.numParticles > particles.Count)
			{
				Particle add = new Particle();

				addFunc(ref add);
				particles.Add(add);
			}
			if (UpdateParticle.ReferenceEquals(this, null) == true)
				return;
			for (int i = 0; i < particles.Count; i++)
			{
				Particle kill = particles[i];
				bool die = !updateFunc(ref kill);
				particles[i] = kill;
				if (die == true
					|| particles[i].isAlive == false
					|| particles.Count > emitter.numParticles)
				{
					particles.Remove(particles[i]);
				}
			
			}
		}
	}
}
