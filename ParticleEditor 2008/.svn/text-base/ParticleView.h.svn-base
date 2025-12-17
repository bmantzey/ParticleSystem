#import <Cocoa/Cocoa.h>
#import "TextureManager.h"
#import "ParticleEngine.h"
#import "CPhysicsTimer.h"

@interface ParticleView : NSOpenGLView
{
	//// Interface Builder
	/// Emitter
    IBOutlet NSForm *emDirection;
    IBOutlet NSForm *emPosition;
    IBOutlet NSForm *emSize;
    IBOutlet NSButton *randDirection;
    IBOutlet NSButton *randPos;
    IBOutlet NSButton *randEmSize;
	// Run Times/Duration
	IBOutlet NSButton *emDuration;
	IBOutlet NSTextField *emDurTime;
	IBOutlet NSButton *emRunAgain;
	/// Particles
	// General
    IBOutlet NSForm *parAccel;
    IBOutlet NSForm *parLife;
    IBOutlet NSTextField *parNum;
    IBOutlet NSForm *parRotation;
    IBOutlet NSForm *parSize;
    IBOutlet NSTextField *parSpeed;
    IBOutlet NSButton *randAccel;
    IBOutlet NSButton *randLifetime;
    IBOutlet NSButton *randParSize;
    IBOutlet NSButton *randParticles;
    IBOutlet NSButton *randRot;
    IBOutlet NSButton *randSpeed;
	IBOutlet NSButton *randSelectAll;
	// Color
    IBOutlet NSMatrix *startColor;
    IBOutlet NSMatrix *endColor;
    IBOutlet NSButton *randStartColor;
    IBOutlet NSButton *randEndColor;
	IBOutlet NSForm *startColorFloat;
	IBOutlet NSForm *endColorFloat;
	////////////////////////////
	//// View
	/// Emitter
	
	/// Particles
	// General
	
	// Color
	
	TextureManager *m_pTM;
	ParticleEngine *m_pPE;
	CPhysicsTimer *m_pTT;
	
	NSTimer *runTimer;
}

- (IBAction)runAgain:(id)sender;
- (IBAction)setEmitterDuration:(id)sender;

- (IBAction)changeEmitter:(id)sender;
- (IBAction)changeParticles:(id)sender;
- (IBAction)randomize:(id)sender;
- (IBAction)randAll:(id)sender;
- (IBAction)changeColorFloat:(id)sender;
- (IBAction)changeColorSlider:(id)sender;

// Menu
- (IBAction)showOpenPanel:(id)sender;
- (IBAction)showSavePanel:(id)sender;
- (IBAction)colorChanged:(id)sender;


-(void)initGL;
-(void)initApp;
-(void)idle;

@end
