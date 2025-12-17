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
	// TODO: Set the class data to the initial values set in the UI.
	m_pTM = [TextureManager getInstance];
	
	runTimer = [NSTimer scheduledTimerWithTimeInterval:1/TARGET_FPS target:self selector:@selector(idle) userInfo:nil repeats:YES];
	
	[self initGL];
}

-(void)awakeFromNib
{
}

-(void)idle
{
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
	// Load textures

	[m_pTM LoadTexture:@"/Users/bmantzey/Documents/Stratogon/Tools/ParticleEditor/Particles/TGA_NON_RLE/TR_Trinity.tga"];
}

-(void)drawRect:(NSRect)rect
{
    //Draw board

    glClear(GL_COLOR_BUFFER_BIT);
	
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	
	glPushMatrix();
	{
		m_pTM.xPos = m_fEmPosX;
		m_pTM.yPos = m_fEmPosY;
		//m_pTM.xScale = 10.0f;
		//m_pTM.yScale = 10.0f;
		M3DVector4f newColor = { m_fRedStart, m_fGreenStart, m_fBlueStart, m_fAlphaStart };
		[m_pTM SetColor:newColor];
		[m_pTM Draw:@"/Users/bmantzey/Documents/Stratogon/Tools/ParticleEditor/Particles/TGA_NON_RLE/TR_Trinity.tga"];
	} glPopMatrix();
	
   // glEnd();
    glFlush();
}

- (IBAction)changeEmitter:(id)sender
{
	// Position
	m_fEmPosX = [[emPosition cellWithTag:0] floatValue];
	m_fEmPosY = [[emPosition cellWithTag:1] floatValue];
	// Size
	m_fEmSizeX = [[emSize cellWithTag:0] floatValue];
	m_fEmSizeY = [[emSize cellWithTag:1] floatValue];
	// Direction
	m_fEmDirBegin = [[emDirection cellWithTag:0] floatValue];
	m_fEmDirEnd = [[emDirection cellWithTag:1] floatValue];
}
- (IBAction)changeParticles:(id)sender
{
	// Number of Particles
	m_nParNum = [parNum intValue];
	// Speed
	m_fParSpeed = [parSpeed floatValue];
	// Lifetime
	m_fParLifeBegin = [[parLife cellWithTag:0] floatValue];
	m_fParLifeEnd = [[parLife cellWithTag:1] floatValue];
	// Acceleration
	m_fParAccelX = [[parAccel cellWithTag:0] floatValue];
	m_fParAccelY = [[parAccel cellWithTag:1] floatValue];
	// Size
	m_fParSizeX = [[parSize cellWithTag:0] floatValue];
	m_fParSizeY = [[parSize cellWithTag:1] floatValue];
	// Rotation
	m_fParRotationBegin = [[parRotation cellWithTag:0] floatValue];
	m_fParRotationEnd = [[parRotation cellWithTag:1] floatValue];
	// Start Color
	m_fRedStart = [[startColor cellWithTag:0] floatValue];
	m_fGreenStart = [[startColor cellWithTag:1] floatValue];
	m_fBlueStart = [[startColor cellWithTag:2] floatValue];
	m_fAlphaStart = [[startColor cellWithTag:3] floatValue];
	// End color
	m_fRedEnd = [[endColor cellWithTag:0] floatValue];
	m_fGreenEnd = [[endColor cellWithTag:1] floatValue];
	m_fBlueEnd = [[endColor cellWithTag:2] floatValue];
	m_fAlphaEnd = [[endColor cellWithTag:3] floatValue];
	
	[self setNeedsDisplay:YES];
}
- (IBAction)changeRandom:(id)sender
{
	m_bRandStartColor = [randStartColor state] == NSOnState;
	m_bRandEndColor = [randEndColor state] == NSOnState;
	m_bRandRot = [randRot state] == NSOnState;
	m_bRandParSize = [randParSize state] == NSOnState;
	m_bRandParNum = [randParticles state] == NSOnState;
	m_bRandSpeed = [randSpeed state] == NSOnState;
	m_bRandLifetime = [randLifetime state] == NSOnState;
	m_bRandAccel = [randAccel state] == NSOnState;
	m_bRandPos = [randPos state] == NSOnState;
	m_bRandEmSize = [randEmSize state] == NSOnState;
	m_bRandDirection = [randDirection state] == NSOnState;
	
	[self setNeedsDisplay:YES];
}
- (IBAction)randAll:(id)sender
{
	BOOL newVal = ([randSelectAll state] == NSOnState);
	m_bRandStartColor = m_bRandEndColor = m_bRandRot = m_bRandParSize = m_bRandParNum = m_bRandSpeed = 
	m_bRandLifetime = m_bRandAccel = m_bRandPos = m_bRandEmSize = m_bRandDirection = newVal;
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

- (IBAction)randomize:(id)sender
{
	int test = 0;
	test++;	
}


@end
