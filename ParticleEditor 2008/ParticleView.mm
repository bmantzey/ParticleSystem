#import "ParticleView.h"

#define TARGET_FPS 60.0

@implementation ParticleView

- (id)initWithFrame:(NSRect)frameRect
		pixelFormat:(NSOpenGLPixelFormat *)pixFmt
{
	self = [super initWithFrame:frameRect pixelFormat:pixFmt];
	[self initApp];
	return self;
}

- (id)initWithCoder:(NSCoder *)c
{
	self = [super initWithCoder:c];
	[self initApp];
	return self;
}

-(void)initApp
{
	[self initGL];

	m_pTM = [TextureManager getInstance];
	m_pTT = [[CPhysicsTimer alloc] init];
	[m_pTT Reset];
	
	NSBundle *mainAppBundle = [NSBundle mainBundle];
	NSString* texture = [[mainAppBundle pathForImageResource:@"TR_Cross.tga"] retain];
	m_pPE = [[ParticleEngine alloc] initWithTexture:texture];
	[texture release];
	
	runTimer = [NSTimer scheduledTimerWithTimeInterval:1/TARGET_FPS target:self selector:@selector(idle) userInfo:nil repeats:YES];
}
-(void)dealloc
{
	[m_pTM release];
	[m_pPE dealloc];

	[super dealloc];
}

// This is an overridden function that responds to the event that the nib file finishes loading.
// The nib file contains all the data in the UI and it is loaded when the app starts up.
-(void)awakeFromNib
{
	m_pPE.m_nNumParticles = [[[parNum cell] placeholderString] intValue];
	
	m_pPE.m_fEmDirBegin = [[[emDirection cellWithTag:0] placeholderString] floatValue];
	m_pPE.m_fEmDirEnd = [[[emDirection cellWithTag:1] placeholderString] floatValue];
	m_pPE.m_fEmPosX = [[[emPosition cellWithTag:0] placeholderString] floatValue];
	m_pPE.m_fEmPosY = [[[emPosition cellWithTag:1] placeholderString] floatValue];
	m_pPE.m_fEmSizeX = [[[emSize cellWithTag:0] placeholderString] floatValue];
	m_pPE.m_fEmSizeY = [[[emSize cellWithTag:1] placeholderString] floatValue];
	m_pPE.m_bRandDirection = [randDirection state] == NSOnState;
	m_pPE.m_bRandPos = [randPos state] == NSOnState;
	m_pPE.m_bRandEmSize = [randEmSize state] == NSOnState;
	m_pPE.m_fParAccelX = [[[parAccel cellWithTag:0] placeholderString] floatValue];
	m_pPE.m_fParAccelY = [[[parAccel cellWithTag:1] placeholderString] floatValue];
	m_pPE.m_fParLifeMin = [[[parLife cellWithTag:0] placeholderString] floatValue];
	m_pPE.m_fParLifeMax = [[[parLife cellWithTag:1] placeholderString] floatValue];
	m_pPE.m_fParRotationBegin = [[[parRotation cellWithTag:0] placeholderString] floatValue];
	m_pPE.m_fParRotationEnd = [[[parRotation cellWithTag:1] placeholderString] floatValue];
	m_pPE.m_fParSizeBegin = [[[parSize cellWithTag:0] placeholderString] floatValue];
	m_pPE.m_fParSizeEnd = [[[parSize cellWithTag:1] placeholderString] floatValue];
	m_pPE.m_fParSpeed = [parSpeed floatValue];
	m_pPE.m_bRandAccel = [randAccel state] == NSOnState;
	m_pPE.m_bRandLifetime = [randLifetime state] == NSOnState;
	m_pPE.m_bRandParSize = [randParSize state] == NSOnState;
	m_pPE.m_bRandParNum = [randParticles state] == NSOnState;
	m_pPE.m_bRandRot = [randRot state] == NSOnState;
	m_pPE.m_bRandSpeed = [randSpeed state] == NSOnState;
	m_pPE.m_fRedStart = [[startColor cellWithTag:0] floatValue];
	m_pPE.m_fGreenStart = [[startColor cellWithTag:1] floatValue];
	m_pPE.m_fBlueStart = [[startColor cellWithTag:2] floatValue];
	m_pPE.m_fAlphaStart = [[startColor cellWithTag:3] floatValue];
	m_pPE.m_fRedEnd = [[endColor cellWithTag:0] floatValue];
	m_pPE.m_fGreenEnd = [[endColor cellWithTag:1] floatValue];
	m_pPE.m_fBlueEnd = [[endColor cellWithTag:2] floatValue];
	m_pPE.m_fAlphaEnd = [[endColor cellWithTag:3] floatValue];
	m_pPE.m_bRandStartColor = [randStartColor state] == NSOnState;
	m_pPE.m_bRandEndColor = [randEndColor state] == NSOnState;
	
	[m_pPE UpdateEmitter];
}

-(void)idle
{
	[m_pTT Update];
	[m_pPE Update:[m_pTT GetDeltaTime]];
	[self drawRect:[self bounds]];
}

-(void)initGL
{
	NSOpenGLContext *glcontext;
	glcontext = [self openGLContext];
	[glcontext makeCurrentContext];
	
	glClearColor(0.0, 0.0, 0.0, 1.0);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	glOrtho(0.0, 781.0, 611.0, 0.0, -1.0, 1.0);
	
	// Set a blending function to use
	glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
	// Enable blending
	glEnable(GL_BLEND);
	glAlphaFunc(GL_GREATER, 0.1F);
	glEnable(GL_ALPHA_TEST);
	// Enable use of the texture
	glEnable(GL_TEXTURE_2D);
	glDisable(GL_CULL_FACE);
}

-(void)drawRect:(NSRect)rect
{
    //Draw board

    glClear(GL_COLOR_BUFFER_BIT);
	
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	
	glPushMatrix();
	{
		[m_pPE RenderParticleSystem];
		
	} glPopMatrix();
	
    glFlush();
}

- (IBAction)setEmitterDuration:(id)sender
{
	if([emDuration state] == NSOnState)
	{
		[emDurTime setEnabled:YES];
		[emRunAgain setEnabled:YES];
		[m_pPE SetRunTime:[emDurTime floatValue]];
	}
	else
	{
		[emDurTime setEnabled:NO];
		[emRunAgain setEnabled:NO];
		[m_pPE ResumeRun];
	}
}
- (IBAction)runAgain:(id)sender
{
	[m_pPE SetRunTime:[emDurTime floatValue]];
}



- (IBAction)colorChanged:(id)sender
{
	NSColor *newColorNS = [sender color];
	CGFloat newColor[4];
	[newColorNS getRed:&newColor[R] green:&newColor[G] blue:&newColor[B] alpha:&newColor[A]];
	glClearColor(newColor[R], newColor[G], newColor[B], newColor[A]);
}

- (IBAction)changeEmitter:(id)sender
{
	// Position
	m_pPE.m_fEmPosX = [[emPosition cellWithTag:0] floatValue];
	m_pPE.m_fEmPosY = [[emPosition cellWithTag:1] floatValue];
	// Size
	m_pPE.m_fEmSizeX = [[emSize cellWithTag:0] floatValue];
	m_pPE.m_fEmSizeY = [[emSize cellWithTag:1] floatValue];
	// Direction
	m_pPE.m_fEmDirBegin = [[emDirection cellWithTag:0] floatValue];
	m_pPE.m_fEmDirEnd = [[emDirection cellWithTag:1] floatValue];
	
	[m_pPE UpdateEmitter];
}
- (IBAction)changeParticles:(id)sender
{
	// Number of Particles
	m_pPE.m_nNumParticles = [parNum intValue];
	// Speed
	m_pPE.m_fParSpeed = [parSpeed floatValue];
	// Lifetime
	m_pPE.m_fParLifeMin = [[parLife cellWithTag:LOW] floatValue];
	m_pPE.m_fParLifeMax = [[parLife cellWithTag:HIGH] floatValue];
	// Acceleration
	m_pPE.m_fParAccelX = [[parAccel cellWithTag:X] floatValue];
	m_pPE.m_fParAccelY = [[parAccel cellWithTag:Y] floatValue];
	// Size
	m_pPE.m_fParSizeBegin = [[parSize cellWithTag:BEGIN] floatValue];
	m_pPE.m_fParSizeEnd = [[parSize cellWithTag:END] floatValue];
	// Rotation
	m_pPE.m_fParRotationBegin = [[parRotation cellWithTag:BEGIN] floatValue];
	m_pPE.m_fParRotationEnd = [[parRotation cellWithTag:END] floatValue];
	
	[m_pPE UpdateEmitter];	
	[self setNeedsDisplay:YES];
}
- (IBAction)changeColorFloat:(id)sender
{
	[[endColorFloat cellWithTag:R] setFloatValue:[[endColor cellWithTag:R] floatValue]];
	[[endColorFloat cellWithTag:G] setFloatValue:[[endColor cellWithTag:G] floatValue]];
	[[endColorFloat cellWithTag:B] setFloatValue:[[endColor cellWithTag:B] floatValue]];
	[[endColorFloat cellWithTag:A] setFloatValue:[[endColor cellWithTag:A] floatValue]];

	[[startColorFloat cellWithTag:R] setFloatValue:[[startColor cellWithTag:R] floatValue]];
	[[startColorFloat cellWithTag:G] setFloatValue:[[startColor cellWithTag:G] floatValue]];
	[[startColorFloat cellWithTag:B] setFloatValue:[[startColor cellWithTag:B] floatValue]];
	[[startColorFloat cellWithTag:A] setFloatValue:[[startColor cellWithTag:A] floatValue]];
	// Start Color
	m_pPE.m_fRedStart = [[startColor cellWithTag:R] floatValue];
	m_pPE.m_fGreenStart = [[startColor cellWithTag:G] floatValue];
	m_pPE.m_fBlueStart = [[startColor cellWithTag:B] floatValue];
	m_pPE.m_fAlphaStart = [[startColor cellWithTag:A] floatValue];
	// End color
	m_pPE.m_fRedEnd = [[endColor cellWithTag:R] floatValue];
	m_pPE.m_fGreenEnd = [[endColor cellWithTag:G] floatValue];
	m_pPE.m_fBlueEnd = [[endColor cellWithTag:B] floatValue];
	m_pPE.m_fAlphaEnd = [[endColor cellWithTag:A] floatValue];

	[m_pPE UpdateEmitter];	
}
- (IBAction)changeColorSlider:(id)sender
{
	[[endColor cellWithTag:R] setFloatValue:[[endColorFloat cellWithTag:R] floatValue]];
	[[endColor cellWithTag:G] setFloatValue:[[endColorFloat cellWithTag:G] floatValue]];
	[[endColor cellWithTag:B] setFloatValue:[[endColorFloat cellWithTag:B] floatValue]];
	[[endColor cellWithTag:A] setFloatValue:[[endColorFloat cellWithTag:A] floatValue]];

	[[startColor cellWithTag:R] setFloatValue:[[startColorFloat cellWithTag:R] floatValue]];
	[[startColor cellWithTag:G] setFloatValue:[[startColorFloat cellWithTag:G] floatValue]];
	[[startColor cellWithTag:B] setFloatValue:[[startColorFloat cellWithTag:B] floatValue]];
	[[startColor cellWithTag:A] setFloatValue:[[startColorFloat cellWithTag:A] floatValue]];
	// Start Color
	m_pPE.m_fRedStart = [[startColor cellWithTag:R] floatValue];
	m_pPE.m_fGreenStart = [[startColor cellWithTag:G] floatValue];
	m_pPE.m_fBlueStart = [[startColor cellWithTag:B] floatValue];
	m_pPE.m_fAlphaStart = [[startColor cellWithTag:A] floatValue];
	// End color
	m_pPE.m_fRedEnd = [[endColor cellWithTag:R] floatValue];
	m_pPE.m_fGreenEnd = [[endColor cellWithTag:G] floatValue];
	m_pPE.m_fBlueEnd = [[endColor cellWithTag:B] floatValue];
	m_pPE.m_fAlphaEnd = [[endColor cellWithTag:A] floatValue];

	[m_pPE UpdateEmitter];	
}

- (IBAction)randAll:(id)sender
{
	BOOL newVal = ([randSelectAll state] == NSOnState);
	m_pPE.m_bRandStartColor = m_pPE.m_bRandEndColor = m_pPE.m_bRandRot = m_pPE.m_bRandParSize = m_pPE.m_bRandParNum = m_pPE.m_bRandSpeed = 
	m_pPE.m_bRandLifetime = m_pPE.m_bRandAccel = m_pPE.m_bRandPos = m_pPE.m_bRandEmSize = m_pPE.m_bRandDirection = newVal;
	[randStartColor setState:newVal];
	[randEndColor setState:newVal];
	[randRot setState:newVal];
	[randParSize setState:newVal];
	[randParticles setState:newVal];
	[randSpeed setState:newVal];
	[randLifetime setState:newVal];
	[randAccel setState:newVal];
	[randPos setState:newVal];
	[randEmSize setState:newVal];
	[randDirection setState:newVal];
	
	[self setNeedsDisplay:YES];
}


// TODO: Write the exporting and importing menu functions for both the binary io and the serialized save.
// TODO: Load particle textures.


- (void)openPanelDidEndLoadTexture:(NSOpenPanel *)op
						returnCode:(int)returnCode
					   contextInfo:(void *)ci
{
	if (returnCode == NSOKButton)
	{
		[m_pPE ChangeTexture:[op filename]];
	}
}

-(void)openPanelDidEndImport:(NSOpenPanel *)op
				  returnCode:(int)returnCode
				 contextInfo:(void *)ci
{
	if (returnCode == NSOKButton)
	{
		// Load a saved work file here.
		NSString *filePath = [op filename];
		NSData *inData = [[NSData alloc] initWithContentsOfFile:filePath];
		tEmitter tempEmitter;
		[inData getBytes:(void*)&tempEmitter length:sizeof(tEmitter)];
		m_pPE.m_tEmitter = tempEmitter;
		
		// End Color
		m_pPE.m_fAlphaEnd = tempEmitter.endColor[A];
		m_pPE.m_fBlueEnd = tempEmitter.endColor[B];
		m_pPE.m_fGreenEnd = tempEmitter.endColor[G];
		m_pPE.m_fRedEnd = tempEmitter.endColor[R];
		[[endColor cellWithTag:R] setFloatValue:tempEmitter.endColor[R]];
		[[endColor cellWithTag:G] setFloatValue:tempEmitter.endColor[G]];
		[[endColor cellWithTag:B] setFloatValue:tempEmitter.endColor[B]];
		[[endColor cellWithTag:A] setFloatValue:tempEmitter.endColor[A]];
		// Start Color
		m_pPE.m_fAlphaStart = tempEmitter.startColor[A];
		m_pPE.m_fBlueStart = tempEmitter.startColor[B];
		m_pPE.m_fGreenStart = tempEmitter.startColor[G];
		m_pPE.m_fRedStart = tempEmitter.startColor[R];
		[[startColor cellWithTag:R] setFloatValue:tempEmitter.startColor[R]];
		[[startColor cellWithTag:G] setFloatValue:tempEmitter.startColor[G]];
		[[startColor cellWithTag:B] setFloatValue:tempEmitter.startColor[B]];
		[[startColor cellWithTag:A] setFloatValue:tempEmitter.startColor[A]];
		// Rotation
		m_pPE.m_fParRotationEnd = tempEmitter.rotationEnd;
		m_pPE.m_fParRotationBegin = tempEmitter.rotationBegin;
		[[parRotation cellWithTag:BEGIN] setFloatValue:tempEmitter.rotationBegin];
		[[parRotation cellWithTag:END] setFloatValue:tempEmitter.rotationEnd];
		// Particle Size
		m_pPE.m_fParSizeEnd = tempEmitter.endSize;
		m_pPE.m_fParSizeBegin = tempEmitter.beginSize;
		[[parSize cellWithTag:BEGIN] setFloatValue:tempEmitter.beginSize];
		[[parSize cellWithTag:END] setFloatValue:tempEmitter.endSize];
		// Particle Acceleration OMG
		m_pPE.m_fParAccelX = tempEmitter.acceleration[X];
		m_pPE.m_fParAccelY = tempEmitter.acceleration[Y];
		[[parAccel cellWithTag:X] setFloatValue:tempEmitter.acceleration[X]];
		[[parAccel cellWithTag:Y] setFloatValue:tempEmitter.acceleration[Y]];
		// Particle Lifetime
		m_pPE.m_fParLifeMax = tempEmitter.maxLifetime;
		m_pPE.m_fParLifeMin = tempEmitter.minLifetime;
		[[parLife cellWithTag:HIGH] setFloatValue:tempEmitter.maxLifetime];
		[[parLife cellWithTag:LOW] setFloatValue:tempEmitter.minLifetime];
		// Number of Particles
		m_pPE.m_nNumParticles = tempEmitter.numParticles;
		[parNum setIntValue:tempEmitter.numParticles];
		// Particle Initial Speed
		m_pPE.m_fParSpeed = tempEmitter.speed;
		[parSpeed setFloatValue:tempEmitter.speed];
		// Emitter Direction
		m_pPE.m_fEmDirBegin = tempEmitter.directionBegin;
		m_pPE.m_fEmDirEnd = tempEmitter.directionEnd;
		[[emDirection cellWithTag:BEGIN] setFloatValue:tempEmitter.directionBegin];
		[[emDirection cellWithTag:END] setFloatValue:tempEmitter.directionEnd];
		// Emitter Size
		m_pPE.m_fEmSizeX = tempEmitter.size.width;
		m_pPE.m_fEmSizeY = tempEmitter.size.height;
		[[emSize cellWithTag:X] setFloatValue:tempEmitter.size.width];
		[[emSize cellWithTag:Y] setFloatValue:tempEmitter.size.height];
		// Emitter Position
		m_pPE.m_fEmPosX = tempEmitter.position[X];
		m_pPE.m_fEmPosY = tempEmitter.position[Y];
		[[emPosition cellWithTag:X] setFloatValue:tempEmitter.position[X]];
		[[emPosition cellWithTag:Y] setFloatValue:tempEmitter.position[Y]];
		// Duration
		m_pPE.m_fRunTime = tempEmitter.m_fRunTime;
		m_pPE.m_bRunLimited = tempEmitter.m_bRunLimited;
		[emDurTime setFloatValue:tempEmitter.m_fRunTime];
		if(tempEmitter.m_bRunLimited)
		{
			[emDuration setState:NSOnState];
			[emRunAgain setEnabled:YES];
			[emDurTime setEnabled:YES];
		}
		else
		{
			[emDuration setState:NSOffState];
			[emRunAgain setEnabled:NO];
			[emDurTime setEnabled:NO];
		}
		
		[self setNeedsDisplay:YES];
	}	
}

- (void)savePanelDidEndExport:(NSSavePanel*)sp
				   returnCode:(int)returnCode
				  contextInfo:(void *)ci
{
	if(returnCode == NSOKButton)
	{
		// Export
		NSString *filePath = [sp filename];
		tEmitter outEmitter = m_pPE.m_tEmitter;
		outEmitter.m_bRunLimited = [emDuration state] == NSOnState;
		outEmitter.m_fRunTime = [emDurTime floatValue];
		NSData *outData = [[NSData alloc] initWithBytes:(void*)&outEmitter length:sizeof(tEmitter)];
		[outData writeToFile:filePath atomically:NO];
	}
}


- (IBAction)showOpenPanel:(id)sender
{
	
	NSString *st = [sender title];
	NSOpenPanel *op = [NSOpenPanel openPanel];
	
	if([st isEqualToString:@"Load Particle Texture..."])
	{
		NSArray *fileTypes = [[NSArray alloc] initWithObjects:@"tga", nil];
		[op beginSheetForDirectory:nil
							  file:nil
							 types:fileTypes
					modalForWindow:[self window]
					 modalDelegate:self
					didEndSelector:@selector(openPanelDidEndLoadTexture:returnCode:contextInfo:)
					   contextInfo:nil];
	}
	else if ([st isEqualToString:@"Import Binary..."])
	{
		NSArray *fileTypes = [[NSArray alloc] initWithObjects:@"peb", nil];
		[op beginSheetForDirectory:nil
							  file:nil
							 types:fileTypes
					modalForWindow:[self window]
					 modalDelegate:self
					didEndSelector:@selector(openPanelDidEndImport:returnCode:contextInfo:)
					   contextInfo:nil];
	}
}

- (IBAction)showSavePanel:(id)sender
{
	NSSavePanel *sp = [NSSavePanel savePanel];
	
	[sp beginSheetForDirectory:nil
						  file:nil 
				modalForWindow:[self window]
				 modalDelegate:self
				didEndSelector:@selector(savePanelDidEndExport:returnCode:contextInfo:)
				   contextInfo:nil];
}


- (IBAction)randomize:(id)sender
{
	float randFloat = 0.0f;
	int randInt;
	NSNumberFormatter *format;
	NSNumber *min;
	NSNumber *max;
	float fmax, fmin;
	
	// Start Color
	if([randStartColor state] == NSOnState)
	{
		fmax = [[startColor cellWithTag:R] maxValue];
		fmin = [[startColor cellWithTag:R] minValue];
		m_pPE.m_fRedStart = randFloat = RAND_FLOAT(fmin, fmax);
		[[startColor cellWithTag:R] setFloatValue:randFloat];
		[[startColorFloat cellWithTag:R] setFloatValue:randFloat];

		fmax = [[startColor cellWithTag:G] maxValue];
		fmin = [[startColor cellWithTag:G] minValue];
		m_pPE.m_fGreenStart = randFloat = RAND_FLOAT(fmin, fmax);
		[[startColor cellWithTag:G] setFloatValue:randFloat];
		[[startColorFloat cellWithTag:G] setFloatValue:randFloat];
		
		fmax = [[startColor cellWithTag:B] maxValue];
		fmin = [[startColor cellWithTag:B] minValue];
		m_pPE.m_fBlueStart = randFloat = RAND_FLOAT(fmin, fmax);
		[[startColor cellWithTag:B] setFloatValue:randFloat];
		[[startColorFloat cellWithTag:B] setFloatValue:randFloat];
		
		fmax = [[startColor cellWithTag:A] maxValue];
		fmin = [[startColor cellWithTag:A] minValue];
		m_pPE.m_fAlphaStart = randFloat = RAND_FLOAT(fmin, fmax);
		[[startColor cellWithTag:A] setFloatValue:randFloat];
		[[startColorFloat cellWithTag:A] setFloatValue:randFloat];
	}
	// End Color
	if([randEndColor state] == NSOnState)
	{
		fmax = [[endColor cellWithTag:R] maxValue];
		fmin = [[endColor cellWithTag:R] minValue];
		m_pPE.m_fRedEnd = randFloat = RAND_FLOAT(fmin, fmax);
		[[endColor cellWithTag:R] setFloatValue:randFloat];
		[[endColorFloat cellWithTag:R] setFloatValue:randFloat];

		fmax = [[endColor cellWithTag:G] maxValue];
		fmin = [[endColor cellWithTag:G] minValue];
		m_pPE.m_fGreenEnd = randFloat = RAND_FLOAT(fmin, fmax);
		[[endColor cellWithTag:G] setFloatValue:randFloat];
		[[endColorFloat cellWithTag:G] setFloatValue:randFloat];
		
		fmax = [[endColor cellWithTag:B] maxValue];
		fmin = [[endColor cellWithTag:B] minValue];
		m_pPE.m_fBlueEnd = randFloat = RAND_FLOAT(fmin, fmax);
		[[endColor cellWithTag:B] setFloatValue:randFloat];
		[[endColorFloat cellWithTag:B] setFloatValue:randFloat];
		
		fmax = [[endColor cellWithTag:A] maxValue];
		fmin = [[endColor cellWithTag:A] minValue];
		m_pPE.m_fAlphaEnd = randFloat = RAND_FLOAT(fmin, fmax);
		[[endColor cellWithTag:A] setFloatValue:randFloat];
		[[endColorFloat cellWithTag:A] setFloatValue:randFloat];
	}
	// Rotation
	if([randRot state] == NSOnState)
	{
		format = [[parRotation cellWithTag:BEGIN] formatter];
		min = [format minimum];
		max = [format maximum];
		m_pPE.m_fParRotationBegin = randFloat = RAND_FLOAT([min floatValue], [max floatValue]);
		[[parRotation cellWithTag:BEGIN] setFloatValue:randFloat];
		
		format = [[parRotation cellWithTag:END] formatter];
		min = [format minimum];
		max = [format maximum];
		m_pPE.m_fParRotationEnd = randFloat = RAND_FLOAT([min floatValue], [max floatValue]);
		[[parRotation cellWithTag:END] setFloatValue:randFloat];
	}
	// Particle Size
	if([randParSize state] == NSOnState)
	{
		format = [[parSize cellWithTag:BEGIN] formatter];
		max = [format maximum];
		min = [format minimum];
		m_pPE.m_fParSizeBegin = randFloat = RAND_FLOAT([min floatValue], [max floatValue]);
		[[parSize cellWithTag:BEGIN] setFloatValue:randFloat];
		
		format = [[parSize cellWithTag:END] formatter];
		max = [format maximum];
		min = [format minimum];
		m_pPE.m_fParSizeEnd = randFloat = RAND_FLOAT([min floatValue], [max floatValue]);
		[[parSize cellWithTag:END] setFloatValue:randFloat];
	}
	// Number of Particles
	if([randParticles state] == NSOnState)
	{
		format = [parNum formatter];
		max = [format maximum];
		min = [format minimum];
		m_pPE.m_nNumParticles = randInt = RAND_INT([min intValue], [max intValue]);
		[parNum setIntValue:randInt];
	}
	// Particle Speed
	if([randSpeed state] == NSOnState)
	{
		format = [parSpeed formatter];
		max = [format maximum];
		min = [format minimum];
		m_pPE.m_fParSpeed = randInt = RAND_INT([min intValue], [max intValue]);
		[parSpeed setIntValue:randInt];
	}
	// Particle Lifetime
	if([randLifetime state] == NSOnState)
	{
		format = [[parLife cellWithTag:LOW] formatter];
		max = [format maximum];
		min = [format minimum];
		m_pPE.m_fParLifeMin = randFloat = RAND_FLOAT([min floatValue], [max floatValue]);
		[[parLife cellWithTag:LOW] setFloatValue:randFloat];
		
		format = [[parLife cellWithTag:HIGH] formatter];
		max = [format maximum];
		min = [format minimum];
		m_pPE.m_fParLifeMax = randFloat = RAND_FLOAT([min floatValue], [max floatValue]);
		[[parLife cellWithTag:HIGH] setFloatValue:randFloat];
	}
	// Particle Acceleration
	if([randAccel state] == NSOnState)
	{
		format = [[parAccel cellWithTag:X] formatter];
		max = [format maximum];
		min = [format minimum];
		m_pPE.m_fParAccelX = randFloat = RAND_FLOAT([min floatValue], [max floatValue]);
		[[parAccel cellWithTag:X] setFloatValue:randFloat];
		
		format = [[parAccel cellWithTag:Y] formatter];
		max = [format maximum];
		min = [format minimum];
		m_pPE.m_fParAccelY = randFloat = RAND_FLOAT([min floatValue], [max floatValue]);
		[[parAccel cellWithTag:Y] setFloatValue:randFloat];
	}
	// Emitter Position
	if([randPos state] == NSOnState)
	{
		format = [[emPosition cellWithTag:X] formatter];
		max = [format maximum];
		min = [format minimum];
		m_pPE.m_fEmPosX = randFloat = RAND_FLOAT([min floatValue], [max floatValue]);
		[[emPosition cellWithTag:X] setFloatValue:randFloat];
		
		format = [[emPosition cellWithTag:Y] formatter];
		max = [format maximum];
		min = [format minimum];
		m_pPE.m_fEmPosY = randFloat = RAND_FLOAT([min floatValue], [max floatValue]);
		[[emPosition cellWithTag:Y] setFloatValue:randFloat];
	}
	// Emitter Size
	if([randEmSize state] == NSOnState)
	{
		format = [[emSize cellWithTag:X] formatter];
		max = [format maximum];
		min = [format minimum];
		m_pPE.m_fEmSizeX = randFloat = RAND_FLOAT([min floatValue], [max floatValue]);
		[[emSize cellWithTag:X] setFloatValue:randFloat];
		
		format = [[emSize cellWithTag:Y] formatter];
		max = [format maximum];
		min = [format minimum];
		m_pPE.m_fEmSizeY = randFloat = RAND_FLOAT([min floatValue], [max floatValue]);
		[[emSize cellWithTag:Y] setFloatValue:randFloat];
	}
	// Direction
	if([randDirection state] == NSOnState)
	{
		format = [[emDirection cellWithTag:BEGIN] formatter];
		max = [format maximum];
		min = [format minimum];
		m_pPE.m_fEmDirBegin = randFloat = RAND_FLOAT([min floatValue], [max floatValue]);
		[[emDirection cellWithTag:BEGIN] setFloatValue:randFloat];
		
		format = [[emDirection cellWithTag:END] formatter];
		max = [format maximum];
		min = [format minimum];
		m_pPE.m_fEmDirEnd = randFloat = RAND_FLOAT([min floatValue], [max floatValue]);
		[[emDirection cellWithTag:END] setFloatValue:randFloat];
	}
	
	[m_pPE UpdateEmitter];
	[self setNeedsDisplay:YES];
}


@end
