////////////////////////////////////////////////
//  File:		"MyTimer.cs"
//  Author:		Brandon Mantzey
//
//	Purpose:	Provide accurate timing.
////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ParticleEditor
{
	class MyTimer
	{
		float timeStart;
		float timeDelta;

		float timeLastFrame = -1.0f;


		Stopwatch tictoc = Stopwatch.StartNew();

		///////////////////////////////////////////////////////////////////////////////
		//  Function:		void Reset() 
		//  Last Modified:	March 25, 2007
		//
		//  Purpose:		Use to initialize & to start timer.  All time calculations
		//					are calculated from game time at this point.
		///////////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Use to initialize & start timer.  All time calculations are calculated from game time at this point.
		/// </summary>
		public void Reset(  )
		{
			// get processor frequency
			//Stopwatch.Frequency; // C#
			//QueryPerformanceFrequency(&tickFrequency); // C++

			// get current tick count
			//tictoc.ElapsedTicks; // C#
			//QueryPerformanceCounter(&ticks); // C++

			// init time at start
			//timeStart = (float)ticks.QuadPart / (float)tickFrequency.QuadPart;
			timeStart = (float)tictoc.ElapsedTicks / (float)Stopwatch.Frequency;
		}

		///////////////////////////////////////////////////////////////////////////////
		//  Function:		void Update() 
		//  Last Modified:	March 25, 2007
		//
		//  Purpose:		Use to update timer.  Call only once per frame.
		///////////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Use to update timer.  Call only ONCE per frame.
		/// </summary>
	    public void Update(  )
		{
			// locals
			float timeNow = GetTime();
			if (timeLastFrame == -1)
				timeLastFrame = GetTime();

			// calculate delta time
			timeDelta     = ( timeNow - timeLastFrame );
			timeLastFrame = timeNow;

		}

		///////////////////////////////////////////////////////////////////////////////
		//  Function:		float GetTime()
		//  Last Modified:	March 25, 2007
		//
		//  Purpose:		Returns ( in seconds ) the amount of time from last Reset call.
		///////////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Returns (in seconds) the amount of time from the last Reset() call.
		/// </summary>
		/// <returns></returns>
		public float GetTime(  )
		{
			// locals
			float time;

			// get current time ( since computer turned on )
			time = (float)tictoc.ElapsedTicks / (float)Stopwatch.Frequency;

			// calculate time since reset
			return (time - timeStart);
		}

		///////////////////////////////////////////////////////////////////////////////
		//  Function:		float GetTime()
		//  Last Modified:	March 25, 2007
		//
		//  Purpose:		Returns ( in seconds ) the amount of time from last frame.
		///////////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Returns (in seconds) the amount of time from last frame.
		/// </summary>
		/// <returns></returns>
		public float GetDeltaTime()
		{
			return timeDelta;
		}



	}
}
