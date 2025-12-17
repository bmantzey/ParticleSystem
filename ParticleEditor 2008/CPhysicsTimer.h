//
//  CPhysicsTimer.h
//  TrainLoaded
//
//  Created by Brandon Mantzey on 10/22/08.
//

#include <mach/mach.h>
#include <mach/mach_time.h>
#include <unistd.h>

#define NANO_TO_DOUBLE(X) (X*10e-10)


@interface CPhysicsTimer : NSObject
{
	unsigned short FPS;
	uint64_t TimeStart;
	uint64_t TimeDelta;
	// No need to store the end time.  It will be used and discarded.
	uint64_t TimeLastFrame;
	uint64_t TimeElapsed;
	uint64_t ElapsedNano;
	uint64_t TimePrev;	
}

@property unsigned short FPS;

///////////////////////////////////////////////////////////////////////////////
// Use to initialize & to start timer.
// All time calculations are calculated from game time at this point.
///////////////////////////////////////////////////////////////////////////////
-(void) Reset;
///////////////////////////////////////////////////////////////////////////////
// Use to update timer.
// ONLY CALL ONCE PER FRAME!!!
///////////////////////////////////////////////////////////////////////////////
-(void) Update;

-(double) GetTime;
-(double) GetDeltaTime;


@end
