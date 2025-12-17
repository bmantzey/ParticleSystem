using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.IO;

namespace ParticleEditor
{
	/// <summary>
	///	File:		"Form1.cs"
	///	Author:		Brandon Mantzey
	///	Purpose:	Contains all data retrieved from the form, sends that data to the Engine,
	///				implements DirectX.
	/// </summary>
	public partial class Form1 : Form
    {
		const int DX_WIDTH = 800;
		const int DX_HEIGHT = 600;

		/// <summary>
		/// Constructor for Form1
		/// </summary>
        public Form1()  // Constructor
        {
			//System.Diagnostics.Stopwatch.GetTimestamp();
			InitializeComponent();
			tictoc.Reset();
        }
		// Miscellaneous members
		string curPartTex;
		int CurBGColor = Color.Teal.ToArgb();
		Random ize = new Random();
		Engine engine = new Engine();
		// Time Based Movement
		MyTimer tictoc = new MyTimer();
		// DirectX members.
		private Device device = null;
		//private VertexBuffer ParticleBuffer = null;
		private Texture particleTex;
		private Sprite spriteManager = null;
		private Device keyboard;


		/// <summary>
		/// Function:		void timer1_Tick(object sender, EventArgs e) 
		/// Last Modified:	March 26, 2007
		/// Purpose:		Used to render DirectX graphics to the screen per milisecond.
		/// </summary>
		/// <param name="sender">Compiler generated argument.</param>
		/// <param name="e">Compiler generated argument.</param>
		private void timer1_Tick(object sender, EventArgs e)
		{
			tictoc.Update();
			if (device != null)
			{
				
				device.Clear(ClearFlags.Target, CurBGColor, 1, 0);
				device.BeginScene();
				spriteManager.Begin(SpriteFlags.AlphaBlend);

				for(int i=0;i<engine.particles.Count;i++)
				{
					Color drawColor = Color.FromArgb(
						(int)engine.particles[i].currentColor.Alpha,
						(int)engine.particles[i].currentColor.Red,
						(int)engine.particles[i].currentColor.Green,
						(int)engine.particles[i].currentColor.Blue);

					float DrawPoint = 16;
					spriteManager.Draw2D(particleTex, Rectangle.Empty,
						new SizeF(engine.particles[i].currentSize, engine.particles[i].currentSize), /*PointF.Empty*/
						new PointF(DrawPoint, DrawPoint), 0.0f, 
					  engine.particles[i].position,
					    drawColor);
				}
				spriteManager.End();
				device.EndScene();
				device.Present();
			}
			engine.update();
		}

		/// <summary>
		/// Function:		bool UpdateParticle(ref Particle p)
		/// Last Modified:	March 26, 2007
		/// Purpose:		Function is called from Engine through the delegate.
		///					Updates the individual particle passed into this function.
		/// </summary>
		/// <param name="p">The particle to update, changes will be made to this particle and 
		///					those changes will be retained.</param>
		/// <returns>True if the particle lives.  False to destroy the particle.</returns>
		private bool UpdateParticle(ref Engine.Particle p)
		{
			float timer = tictoc.GetDeltaTime();
			p.elapsedTime += (double)timer;
			if (p.elapsedTime >= p.lifeTime)
			{
				p.isAlive = false;
				return false;
			}
			if (ParticleSpeedConstant.Checked == false)
			{
				p.currentVelocity.X += engine.emitter.acceleration.X * timer;
				p.currentVelocity.Y += engine.emitter.acceleration.Y * timer;
			}
			p.position.X += ((float)p.currentVelocity.X * timer);
			p.position.Y += ((float)p.currentVelocity.Y * timer);
		
			p.currentColor = ColorOperator.Lerp(engine.emitter.startColor, engine.emitter.endColor,
				((float)p.elapsedTime / (float)p.lifeTime));
			//spriteManager.Transform.Scale(p.currentSize, p.currentSize, 1.0f);

			if(engine.emitter.beginSize < engine.emitter.endSize) // Starts small -> Gets big
				p.currentSize = (engine.emitter.beginSize + (engine.emitter.endSize * (float)(p.elapsedTime / p.lifeTime)));
			if(engine.emitter.beginSize > engine.emitter.endSize) // Starts big -> gets small
				p.currentSize = engine.emitter.beginSize - (engine.emitter.beginSize - engine.emitter.endSize) *
					(float)(p.elapsedTime / p.lifeTime);

		
			//p.currentSize
			return true;
		}

		/// <summary>
		/// Function:		void AddParticle(ref Particle p)
		/// Last Modified:	March 26, 2007
		/// Purpose:		Function is called from Engine through the delegate.
		///					Creates a new particle based on the default contents as set in the emitter.
		/// </summary>
		/// <param name="p">The particle is created and returned through p.</param>
		private void AddParticle(ref Engine.Particle p)
		{
			p.position.X = ize.Next(engine.emitter.position.X, // from the left edge of the emitter
									engine.emitter.position.X+engine.emitter.size.Width); // to the right edge
			p.position.Y = ize.Next(engine.emitter.position.Y, // from the top edge of the emitter
									engine.emitter.position.Y + engine.emitter.size.Height); // to the bottom
			p.currentColor = engine.emitter.startColor;
			p.currentSize = engine.emitter.beginSize;
			float CurrentAngle = ize.Next((int)engine.emitter.directionBegin,
				(int)engine.emitter.directionEnd);
			p.currentVelocity.X = AngleToVector((double)CurrentAngle).X * (float)engine.emitter.speed;
			p.currentVelocity.Y = AngleToVector((double)CurrentAngle).Y * (float)engine.emitter.speed;

			p.isAlive = true;
			p.elapsedTime = 0.0;
			p.lifeTime = (double)ize.Next((int)engine.emitter.minLifetime,
										  (int)engine.emitter.maxLifetime)/1000;
			spriteManager.Transform.Scale(p.currentSize, p.currentSize, 1.0f);
		}

		/// <summary>
		/// Function:		Vector2 AngleToVector(double angle)
		/// Last Modified:	March 26, 2007
		/// Purpose:		Takes in an angle and returns a normalized vector representing the direction
		///					of that angle.
		/// </summary>
		/// <param name="angle">Uses this angle to create the return vector.</param>
		/// <returns>Normalized representation of the direction passed in.</returns>
		private Vector2 AngleToVector(double angle)
		{
			Vector2 vector;
			vector.X = (float)Math.Cos(angle * (Math.PI/180));
			vector.Y = -(float)Math.Sin(angle * (Math.PI / 180));
			return vector;
		}
		/// <summary>
		/// Function:		void InitGeometry()
		/// Last Modified:	March 26, 2007
		/// Purpose:		All pertainent initialization.
		/// </summary>
		private void InitGeometry()
		{
			engine.updateFunc = new Engine.UpdateParticle(this.UpdateParticle);
			engine.addFunc = new Engine.AddParticle(this.AddParticle);
		}
		/// <summary>
		/// Function:		void Form1_Load(object sender, EventArgs e)
		/// Last Modified:	March 26, 2007
		/// Purpose:		Also contains initialization which is neccessary to happen after the form loads.
		/// </summary>
		/// <param name="sender">Compiler generated argument.</param>
		/// <param name="e">Compiler generated argument.</param>
		private void Form1_Load(object sender, EventArgs e)
		{
			#region Form data initialization (Controls)

			EmitterPositionX.Value = (DX_WIDTH / 2)-20;
			EmitterPositionY.Value = (DX_HEIGHT / 2)-20;
			
			#endregion
			PresentParameters pp = new PresentParameters();
			pp.Windowed = true;
			pp.SwapEffect = SwapEffect.Discard;
			pp.DeviceWindow = DXPanel;
			pp.PresentFlag = PresentFlag.LockableBackBuffer;
			pp.DeviceWindowHandle = DXPanel.Handle;
			pp.BackBufferFormat = Manager.Adapters[0].CurrentDisplayMode.Format;
			pp.BackBufferCount = 1;
			pp.BackBufferWidth = DX_WIDTH;
			pp.BackBufferHeight = DX_HEIGHT;
			pp.PresentationInterval = PresentInterval.Immediate;
			pp.EnableAutoDepthStencil = true;
			pp.AutoDepthStencilFormat = DepthFormat.D16;

			device = new Device(0, DeviceType.Hardware, DXPanel.Handle, CreateFlags.HardwareVertexProcessing,
				pp);
			device.RenderState.ZBufferEnable = true;
			device.RenderState.CullMode = Cull.None;
			device.RenderState.Lighting = false;

			device.RenderState.SourceBlend = Blend.BothSourceAlpha;
			device.RenderState.DestinationBlend = Blend.BothInvSourceAlpha;
			device.RenderState.AlphaBlendEnable = true;


			spriteManager = new Sprite(device);

			particleTex = TextureLoader.FromFile(device, "SS_FlameParticleSoft.tga");

			#region Form data initialization (Internal)

			engine.emitter.numParticles = (int)ParticleNumber.Value;
			engine.emitter.directionBegin = (float)EmitterDirectionBegin.Value;
			engine.emitter.directionEnd = (float)EmitterDirectionEnd.Value;
			engine.emitter.size.Height = (int)EmitterSizeY.Value;
			engine.emitter.size.Width = (int)EmitterSizeX.Value;
			engine.emitter.numParticles = (int)ParticleNumber.Value;
			engine.emitter.position.X = (int)EmitterPositionX.Value;
			engine.emitter.position.Y = (int)EmitterPositionY.Value;
			engine.emitter.speed = (double)ParticleSpeed.Value;
			engine.emitter.minLifetime = (double)ParticleLifetimeBegin.Value;
			engine.emitter.maxLifetime = (double)ParticleLifetimeEnd.Value;
			engine.emitter.acceleration.X = (float)ParticleAccelerationX.Value;
			engine.emitter.acceleration.Y = (float)ParticleAccelerationY.Value;
			engine.emitter.beginSize = (float)ParticleSizeBegin.Value;
			engine.emitter.endSize = (float)ParticleSizeEnd.Value;
			engine.emitter.startColor.Red = (float)ParticleColorBeginRedBox.Value;
			engine.emitter.endColor.Red = (float)ParticleColorBeginRedBox.Value;
			engine.emitter.startColor.Green = (float)ParticleColorBeginGreenBox.Value;
			engine.emitter.endColor.Green = (float)ParticleColorBeginGreenBox.Value;
			engine.emitter.startColor.Blue = (float)ParticleColorBeginBlueBox.Value;
			engine.emitter.endColor.Blue = (float)ParticleColorBeginBlueBox.Value;
			engine.emitter.startColor.Alpha = (float)ParticleColorBeginAlphaBox.Value;
			engine.emitter.endColor.Alpha = (float)ParticleColorBeginAlphaBox.Value;
			InitGeometry();
			#endregion
		}
		/// <summary>
		/// Function:		void Form1_FormClosed(object sender, FormClosedEventArgs e)
		/// Last Modified:	March 26, 2007
		/// Purpose:		The safe release of all DirectX references.
		/// </summary>
		/// <param name="sender">Compiler generated argument.</param>
		/// <param name="e">Compiler generated argument.</param>
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (spriteManager != null)
				spriteManager.Dispose();
			if(particleTex != null)
				particleTex.Dispose();
			//if (ParticleBuffer != null)
			//    ParticleBuffer.Dispose();
			if (device != null)
				device.Dispose();
		}
		#region Control effects

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            #region Hide and show Acceleration Code
            if (ParticleSpeedConstant.Checked == false)
            {
                //ParticleSpeed.Enabled = false;
               // ParticleSpeedRandom.Enabled = false;
                ParticleSpeedConstantLabel.Text = "Start Speed:";
                ParticleAccelerationRandom.Enabled = true;
                ParticleAccelerationLabel.Enabled = true;
                ParticleAccelerationX.Enabled = true;
                ParticleAccelerationXLabel.Enabled = true;
                ParticleAccelerationY.Enabled = true;
                ParticleAccelerationYLabel.Enabled = true;
            }
            else
            {
                ParticleSpeedConstantLabel.Text = "Constant:";
                ParticleSpeedRandom.Enabled = true;
                ParticleSpeed.Enabled = true;
                ParticleSpeedLabel.Enabled = true;
                ParticleAccelerationLabel.Enabled = false;
                ParticleAccelerationX.Enabled = false;
                ParticleAccelerationXLabel.Enabled = false;
                ParticleAccelerationY.Enabled = false;
                ParticleAccelerationYLabel.Enabled = false;
                ParticleAccelerationRandom.Enabled = false;
            }
            #endregion
//            System.Collections.ArrayList myList;
			if (CheckAllRand.Checked == true)
				ParticleAccelerationRandom.Checked = true;
			else
				ParticleAccelerationRandom.Checked = false;
			if (ParticleSpeedConstant.Checked == true)
				ParticleAccelerationRandom.Checked = false;
		//	ParticleEditor.Engine.Emitter test;
		}
        private void ParticleSpeedRandom_CheckedChanged(object sender, EventArgs e)
		{
			//ParticleSpeed.Value = (decimal)ize.Next((int)ParticleSpeed.Maximum/2);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ParticleSizeConstant_CheckedChanged(object sender, EventArgs e)
        {
            #region Hide and Show Size variation code
            if (ParticleSizeConstant.Checked == false)
            {
                //ParticleSizeRandom.Enabled = false;

                ParticleSizeBeginLabel.Visible = true;
                ParticleSizeEndLabel.Enabled = true;
                ParticleSizeEnd.Enabled = true;
                ParticleSizeEndRandom.Enabled = true;
            }
            else
            {
                ParticleSizeBeginLabel.Visible = false;

                ParticleSizeEndLabel.Enabled = false;
                ParticleSizeEnd.Enabled = false;
                ParticleSizeEndRandom.Enabled = false;
            }
            #endregion 

			if (CheckAllRand.Checked == true)
				ParticleSizeEndRandom.Checked = true;
			else
				ParticleSizeEndRandom.Checked = false;
			if (ParticleSizeConstant.Checked == true)
				ParticleSizeEndRandom.Checked = false;
				
		}
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            #region Hide and show color range boxes code
            if (ParticleColorConstant.Checked == false)
            {
                ParticleColorBeginLabel.Text = "Begin Color";

                ParticleColorEndLabel.Enabled = true;
                ParticleColorEndRandLabel.Enabled = true;

                ParticleColorEndRedTrack.Enabled = true;
                ParticleColorEndRedBox.Enabled = true;
                ParticleColorEndRedRand.Enabled = true;
                
                ParticleColorEndGreenTrack.Enabled = true;
                ParticleColorEndGreenBox.Enabled = true;
                ParticleColorEndGreenRand.Enabled = true;
                
                ParticleColorEndBlueTrack.Enabled = true;
                ParticleColorEndBlueBox.Enabled = true;
                ParticleColorEndBlueRand.Enabled = true;

                ParticleColorEndAlphaTrack.Enabled = true;
                ParticleColorEndAlphaBox.Enabled = true;
                ParticleColorEndAlphaRand.Enabled = true;
            }
            else
            {

                ParticleColorBeginLabel.Text = "Constant Color";

                ParticleColorEndLabel.Enabled = false;
                ParticleColorEndRandLabel.Enabled = false;

                ParticleColorEndRedTrack.Enabled = false;
                ParticleColorEndRedBox.Enabled = false;
                ParticleColorEndRedRand.Enabled = false;

                ParticleColorEndGreenTrack.Enabled = false;
                ParticleColorEndGreenBox.Enabled = false;
                ParticleColorEndGreenRand.Enabled = false;

                ParticleColorEndBlueTrack.Enabled = false;
                ParticleColorEndBlueBox.Enabled = false;
                ParticleColorEndBlueRand.Enabled = false;

                ParticleColorEndAlphaTrack.Enabled = false;
                ParticleColorEndAlphaBox.Enabled = false;
                ParticleColorEndAlphaRand.Enabled = false;
            }

            #endregion
			if (CheckAllRand.Checked == true)
			{
				ParticleColorEndGreenRand.Checked = true;
				ParticleColorEndBlueRand.Checked = true;
				ParticleColorEndRedRand.Checked = true;
				ParticleColorEndAlphaRand.Checked = true;
			}
			else
			{
				ParticleColorEndGreenRand.Checked = false;
				ParticleColorEndBlueRand.Checked = false;
				ParticleColorEndRedRand.Checked = false;
				ParticleColorEndAlphaRand.Checked = false;
			}
			if (ParticleColorConstant.Checked == true)
			{
				ParticleColorEndGreenRand.Checked = false;
				ParticleColorEndBlueRand.Checked = false;
				ParticleColorEndRedRand.Checked = false;
				ParticleColorEndAlphaRand.Checked = false;
			}
        }
		#region Tracks and Boxes changing each other.
		private void ParticleColorBeginRedTrack_ValueChanged(object sender, EventArgs e)
		{
			ParticleColorBeginRedBox.Value = ParticleColorBeginRedTrack.Value;
		}
		private void ParticleColorBeginRedBox_ValueChanged(object sender, EventArgs e)
		{
			ParticleColorBeginRedTrack.Value = (int)ParticleColorBeginRedBox.Value;
			engine.emitter.startColor.Red = (byte)ParticleColorBeginRedBox.Value;
		}
		private void ParticleColorBeginGreenBox_ValueChanged(object sender, EventArgs e)
		{
			ParticleColorBeginGreenTrack.Value = (int)ParticleColorBeginGreenBox.Value;
			engine.emitter.startColor.Green = (byte)ParticleColorBeginGreenBox.Value;
		}
		private void ParticleColorBeginGreenTrack_ValueChanged(object sender, EventArgs e)
		{
			ParticleColorBeginGreenBox.Value = ParticleColorBeginGreenTrack.Value;
		}
		private void ParticleColorBeginBlueBox_ValueChanged(object sender, EventArgs e)
		{
			ParticleColorBeginBlueTrack.Value = (int)ParticleColorBeginBlueBox.Value;
			engine.emitter.startColor.Blue = (byte)ParticleColorBeginBlueBox.Value;
		}
		private void ParticleColorBeginBlueTrack_ValueChanged(object sender, EventArgs e)
		{
			ParticleColorBeginBlueBox.Value = ParticleColorBeginBlueTrack.Value;
		}
		private void ParticleColorBeginAlphaBox_ValueChanged(object sender, EventArgs e)
		{
			ParticleColorBeginAlphaTrack.Value = (int)ParticleColorBeginAlphaBox.Value;
			engine.emitter.startColor.Alpha = (byte)ParticleColorBeginAlphaBox.Value;
		}
		private void ParticleColorBeginAlphaTrack_ValueChanged(object sender, EventArgs e)
		{
			ParticleColorBeginAlphaBox.Value = ParticleColorBeginAlphaTrack.Value;
		}
		private void ParticleColorEndRedBox_ValueChanged(object sender, EventArgs e)
		{
			ParticleColorEndRedTrack.Value = (int)ParticleColorEndRedBox.Value;
			engine.emitter.endColor.Red = (byte)ParticleColorEndRedBox.Value;
		}
		private void ParticleColorEndRedTrack_ValueChanged(object sender, EventArgs e)
		{
			ParticleColorEndRedBox.Value = ParticleColorEndRedTrack.Value;
		}
		private void ParticleColorEndGreenBox_ValueChanged(object sender, EventArgs e)
		{
			ParticleColorEndGreenTrack.Value = (int)ParticleColorEndGreenBox.Value;
			engine.emitter.endColor.Green = (byte)ParticleColorEndGreenBox.Value;
		}
		private void ParticleColorEndGreenTrack_ValueChanged(object sender, EventArgs e)
		{
			ParticleColorEndGreenBox.Value = ParticleColorEndGreenTrack.Value;
		}
		private void ParticleColorEndBlueBox_ValueChanged(object sender, EventArgs e)
		{
			ParticleColorEndBlueTrack.Value = (int)ParticleColorEndBlueBox.Value;
			engine.emitter.endColor.Blue = (byte)ParticleColorEndBlueBox.Value;
		}
		private void ParticleColorEndBlueTrack_ValueChanged(object sender, EventArgs e)
		{
			ParticleColorEndBlueBox.Value = ParticleColorEndBlueTrack.Value;
		}
		private void ParticleColorEndAlphaBox_ValueChanged(object sender, EventArgs e)
		{
			ParticleColorEndAlphaTrack.Value = (int)ParticleColorEndAlphaBox.Value;
			engine.emitter.endColor.Alpha = (byte)ParticleColorEndAlphaBox.Value;
		}
		private void ParticleColorEndAlphaTrack_ValueChanged(object sender, EventArgs e)
		{
			ParticleColorEndAlphaBox.Value = ParticleColorEndAlphaTrack.Value;
		}

		#endregion
		private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
		{
			if (CheckAllRand.Checked == true)
			{
				EmitterDirectionRand.Checked = true;
				EmitterPositionRand.Checked = true;
				EmitterSizeRand.Checked = true;
				ParticleNumberRand.Checked = true;
				ParticleLifetimeRand.Checked = true;
				ParticleSpeedRandom.Checked = true;
				if(ParticleSpeedConstant.Checked == false)
					ParticleAccelerationRandom.Checked = true;
				ParticleSizeBeginRandom.Checked = true;
				if(ParticleSizeConstant.Checked == false)
					ParticleSizeEndRandom.Checked = true;
				ParticleColorBeginRedRand.Checked = true;
				ParticleColorBeginBlueRand.Checked = true;
				ParticleColorBeginGreenRand.Checked = true;
				ParticleColorBeginAlphaRand.Checked = true;
				//if (ParticleColorConstant.Checked == false)
				{
					ParticleColorEndGreenRand.Checked = true;
					ParticleColorEndBlueRand.Checked = true;
					ParticleColorEndRedRand.Checked = true;
					ParticleColorEndAlphaRand.Checked = true;
				}
				if (ParticleSizeConstant.Checked == false)
					ParticleSizeEndRandom.Checked = true;
				else
					ParticleSizeEndRandom.Checked = false;
				if (ParticleSpeedConstant.Checked == false)
					ParticleAccelerationRandom.Checked = true;
				else
					ParticleAccelerationRandom.Checked = false;
			}
			else
			{
				EmitterDirectionRand.Checked = false;
				EmitterPositionRand.Checked = false;
				EmitterSizeRand.Checked = false;
				ParticleNumberRand.Checked = false;
				ParticleLifetimeRand.Checked = false;
				ParticleSpeedRandom.Checked = false;
				ParticleAccelerationRandom.Checked = false;
				ParticleSizeBeginRandom.Checked = false;
				ParticleSizeEndRandom.Checked = false;
				ParticleColorBeginRedRand.Checked = false;
				ParticleColorBeginBlueRand.Checked = false;
				ParticleColorBeginGreenRand.Checked = false;
				ParticleColorBeginAlphaRand.Checked = false;
				if (ParticleColorConstant.Checked == false)
				{
					ParticleColorEndGreenRand.Checked = false;
					ParticleColorEndBlueRand.Checked = false;
					ParticleColorEndRedRand.Checked = false;
					ParticleColorEndAlphaRand.Checked = false;
				}
				if (ParticleSizeConstant.Checked == false)
					ParticleSizeEndRandom.Checked = false;
				if (ParticleSpeedConstant.Checked == false)
					ParticleAccelerationRandom.Checked = false;
			}
		}
		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			if (ParticleLifetimeEnd.Value < ParticleLifetimeBegin.Value)
			{
				ParticleLifetimeEnd.Value = ParticleLifetimeBegin.Value;
			}
			engine.emitter.maxLifetime = (double)ParticleLifetimeEnd.Value;
		}
		private void ParticleLifetimeBegin_ValueChanged(object sender, EventArgs e)
		{
			if (ParticleLifetimeBegin.Value > ParticleLifetimeEnd.Value)
			{
				ParticleLifetimeBegin.Value = ParticleLifetimeEnd.Value;
			}
			engine.emitter.minLifetime = (double)ParticleLifetimeBegin.Value;
		}
		private void loadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Stream myStream;
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = ".";
			openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

			openFileDialog1.FilterIndex = 2;
			openFileDialog1.RestoreDirectory = true;

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				if ((myStream = openFileDialog1.OpenFile()) != null)
				{
					// Insert code to read the stream here.
					curPartTex = openFileDialog1.FileName;
					particleTex = TextureLoader.FromFile(device, curPartTex, 0,
						0, 0, Usage.None, Format.Unknown, Pool.Managed,
						Filter.None, Filter.None, 0);
					myStream.Close();
				}
			}
		}
		private void EmitterPositionX_ValueChanged(object sender, EventArgs e)
		{
			engine.emitter.position.X = (int)EmitterPositionX.Value;
		}
		private void EmitterPositionY_ValueChanged(object sender, EventArgs e)
		{
			engine.emitter.position.Y = (int)EmitterPositionY.Value;
		}
		private void EmitterSizeX_ValueChanged(object sender, EventArgs e)
		{
			engine.emitter.size.Width = (int)EmitterSizeX.Value;
		}
		private void ParticleNumber_ValueChanged(object sender, EventArgs e)
		{
			engine.emitter.numParticles = (int)ParticleNumber.Value;
		}
		private void ParticleSpeed_ValueChanged(object sender, EventArgs e)
		{
			engine.emitter.speed = (double)ParticleSpeed.Value;
			
		}
		private void ParticleAccelerationX_ValueChanged(object sender, EventArgs e)
		{
			engine.emitter.acceleration.X = (float)ParticleAccelerationX.Value; 
		}
		private void ParticleAccelerationY_ValueChanged(object sender, EventArgs e)
		{
			engine.emitter.acceleration.Y = (float)ParticleAccelerationY.Value;
		}
		private void ParticleSizeBeginX_ValueChanged(object sender, EventArgs e)
		{
			engine.emitter.beginSize = (float)ParticleSizeBegin.Value;
		}
		private void ParticleSizeEndX_ValueChanged(object sender, EventArgs e)
		{
			engine.emitter.endSize = (float)ParticleSizeEnd.Value;
		}
		private void ParticleColorBeginRedTrack_Scroll(object sender, EventArgs e)
		{
			engine.emitter.startColor.Red = (byte)ParticleColorBeginRedTrack.Value;
		}
		private void ParticleColorEndRedTrack_Scroll(object sender, EventArgs e)
		{
			engine.emitter.endColor.Red = (byte)ParticleColorEndRedTrack.Value;
		}
		private void ParticleColorBeginGreenTrack_Scroll(object sender, EventArgs e)
		{
			engine.emitter.startColor.Green = (byte)ParticleColorBeginGreenTrack.Value;
		}
		private void ParticleColorEndGreenTrack_Scroll(object sender, EventArgs e)
		{
			engine.emitter.endColor.Green = (byte)ParticleColorEndGreenTrack.Value;
		}
		private void ParticleColorBeginBlueTrack_Scroll(object sender, EventArgs e)
		{
			engine.emitter.startColor.Blue = (byte)ParticleColorBeginBlueTrack.Value;
		}
		private void ParticleColorEndBlueTrack_Scroll(object sender, EventArgs e)
		{
			engine.emitter.endColor.Blue = (byte)ParticleColorEndBlueTrack.Value;
		}
		private void ParticleColorBeginAlphaTrack_Scroll(object sender, EventArgs e)
		{
			engine.emitter.startColor.Alpha = (byte)ParticleColorBeginAlphaTrack.Value;
		}
		private void ParticleColorEndAlphaTrack_Scroll(object sender, EventArgs e)
		{
			engine.emitter.endColor.Alpha = (byte)ParticleColorEndAlphaTrack.Value;
		}
		private void EmitterSizeY_ValueChanged(object sender, EventArgs e)
		{
			engine.emitter.size.Height = (int)EmitterSizeY.Value;
		}
		private void EmitterDirectionBegin_ValueChanged(object sender, EventArgs e)
		{
			if (EmitterDirectionBegin.Value <= EmitterDirectionEnd.Value)
				engine.emitter.directionBegin = (float)EmitterDirectionBegin.Value;
			else
			    EmitterDirectionBegin.Value = EmitterDirectionEnd.Value;
		}
		private void EmitterDirectionEnd_ValueChanged(object sender, EventArgs e)
		{
			if (EmitterDirectionEnd.Value >= EmitterDirectionBegin.Value)
				engine.emitter.directionEnd = (float)EmitterDirectionEnd.Value;
			else
			    EmitterDirectionEnd.Value = EmitterDirectionBegin.Value;

		}
		private void ParticleColorBeginRedRand_CheckedChanged(object sender, EventArgs e)
		{
			//ParticleColorBeginRedBox.Value = (decimal)ize.Next(256);
		}
		private void ParticleColorEndAlphaRand_CheckedChanged(object sender, EventArgs e)
		{
		//	ParticleColorEndAlphaBox.Value = (decimal)ize.Next(256);
		}
		private void ParticleColorBeginAlphaRand_CheckedChanged(object sender, EventArgs e)
		{
		//	ParticleColorBeginAlphaBox.Value = (decimal)ize.Next(256);
		}
		private void ParticleColorEndBlueRand_CheckedChanged(object sender, EventArgs e)
		{
			//ParticleColorEndBlueBox.Value = (decimal)ize.Next(256);
		}
		private void ParticleColorBeginBlueRand_CheckedChanged(object sender, EventArgs e)
		{
			//ParticleColorBeginBlueBox.Value = (decimal)ize.Next(256);
		}
		private void ParticleColorEndGreenRand_CheckedChanged(object sender, EventArgs e)
		{
	//		ParticleColorEndGreenBox.Value = (decimal)ize.Next(256);
		}
		private void ParticleColorBeginGreenRand_CheckedChanged(object sender, EventArgs e)
		{
	//		ParticleColorBeginGreenBox.Value = (decimal)ize.Next(256);
		}
		private void ParticleColorEndRedRand_CheckedChanged(object sender, EventArgs e)
		{
	//		ParticleColorEndRedBox.Value = (decimal)ize.Next(256);
		}
		private void ParticleSizeEndRandom_CheckedChanged(object sender, EventArgs e)
		{
		//	ParticleSizeEnd.Value = ParticleSizeEnd.Maximum * (decimal)ize.NextDouble();
		}
		private void ParticleSizeBeginRandom_CheckedChanged(object sender, EventArgs e)
		{
			//ParticleSizeBegin.Value = ParticleSizeBegin.Maximum * (decimal)ize.NextDouble();
		}
		private void ParticleAccelerationRandom_CheckedChanged(object sender, EventArgs e)
		{
			//ParticleAccelerationX.Value = (decimal)ize.Next((int)ParticleAccelerationX.Minimum,
			//    (int)ParticleAccelerationX.Maximum);
			//ParticleAccelerationY.Value = (decimal)ize.Next((int)ParticleAccelerationY.Minimum,
			//    (int)ParticleAccelerationY.Maximum);
		}
		private void ParticleLifetimeRand_CheckedChanged(object sender, EventArgs e)
		{
			//ParticleLifetimeBegin.Value = (decimal)ize.Next((int)ParticleLifetimeBegin.Minimum,
			//    (int)ParticleLifetimeBegin.Maximum);
			//ParticleLifetimeEnd.Value = (decimal)ize.Next((int)ParticleLifetimeEnd.Minimum,
			//    (int)ParticleLifetimeEnd.Maximum);
		}
		private void ParticleNumberRand_CheckedChanged(object sender, EventArgs e)
		{
			//ParticleNumber.Value = (decimal)ize.Next((int)ParticleNumber.Minimum,(int)ParticleNumber.Maximum);
		}
		private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BGColor.ShowDialog();
			CurBGColor = BGColor.Color.ToArgb();
		}
		private void checkBox1_CheckedChanged_3(object sender, EventArgs e)
		{
		}
		private void RandomizeButton_Click(object sender, EventArgs e)
		{
			if(EmitterDirectionRand.Checked == true)
			{
				// direction
				EmitterDirectionBegin.Value = (decimal)ize.Next((int)EmitterDirectionBegin.Minimum,
					(int)EmitterDirectionBegin.Maximum);
				EmitterDirectionEnd.Value = (decimal)ize.Next((int)EmitterDirectionEnd.Minimum,
					(int)EmitterDirectionEnd.Maximum);
			}
			if(EmitterPositionRand.Checked == true)
			{
				// position
				EmitterPositionX.Value = (decimal)ize.Next((int)EmitterPositionX.Minimum,
					(int)EmitterPositionX.Maximum);
				EmitterPositionY.Value = (decimal)ize.Next((int)EmitterPositionY.Minimum,
					(int)EmitterPositionY.Maximum);
			}
			if(EmitterSizeRand.Checked == true)
			{
				// size
				EmitterSizeY.Value = (decimal)ize.Next((int)EmitterSizeY.Minimum,
					(int)EmitterSizeY.Maximum);
				EmitterSizeX.Value = (decimal)ize.Next((int)EmitterSizeX.Minimum,
					(int)EmitterSizeX.Maximum);
			}
			if(ParticleNumberRand.Checked == true)
			{
				ParticleNumber.Value = (decimal)ize.Next((int)ParticleNumber.Minimum,
					(int)ParticleNumber.Maximum);
			}
			if(ParticleLifetimeRand.Checked == true)
			{
				ParticleLifetimeBegin.Value = (decimal)ize.Next((int)ParticleLifetimeBegin.Minimum,
					(int)ParticleLifetimeBegin.Maximum);
				ParticleLifetimeEnd.Value = (decimal)ize.Next((int)ParticleLifetimeEnd.Minimum,
					(int)ParticleLifetimeEnd.Maximum);
			}
			if(ParticleSpeedRandom.Checked == true)
			{
				ParticleSpeed.Value = (decimal)ize.Next((int)ParticleSpeed.Maximum/2);
			}
			if(ParticleAccelerationRandom.Checked == true)
			{
				ParticleAccelerationX.Value = (decimal)ize.Next((int)ParticleAccelerationX.Minimum,
					(int)ParticleAccelerationX.Maximum);
				ParticleAccelerationY.Value = (decimal)ize.Next((int)ParticleAccelerationY.Minimum,
					(int)ParticleAccelerationY.Maximum);
			}
			if(ParticleSizeBeginRandom.Checked == true)
			{
				ParticleSizeBegin.Value = ParticleSizeBegin.Maximum * (decimal)ize.NextDouble();
				if (ParticleSizeConstant.Checked == true)
					ParticleSizeEnd.Value = ParticleSizeBegin.Value;

			}
			if(ParticleSizeEndRandom.Checked == true)
			{
				if (ParticleSizeConstant.Checked == false)
					ParticleSizeEnd.Value = ParticleSizeEnd.Maximum * (decimal)ize.NextDouble();
				else
					ParticleSizeEnd.Value = ParticleSizeBegin.Value;
			}
			if(ParticleColorBeginRedRand.Checked == true)
			{
				ParticleColorBeginRedBox.Value = (decimal)ize.Next(256);
			}
			if(ParticleColorEndRedRand.Checked == true)
			{
				ParticleColorEndRedBox.Value = (decimal)ize.Next(256);
			}
			if( ParticleColorBeginGreenRand.Checked == true)
			{
				ParticleColorBeginGreenBox.Value = (decimal)ize.Next(256);
			}
			if(ParticleColorEndGreenRand.Checked == true)
			{
				ParticleColorEndGreenBox.Value = (decimal)ize.Next(256);
			}
			if(ParticleColorBeginBlueRand.Checked == true)
			{
				ParticleColorBeginBlueBox.Value = (decimal)ize.Next(256);
			}
			if(ParticleColorEndBlueRand.Checked == true)
			{
				ParticleColorEndBlueBox.Value = (decimal)ize.Next(256);
			}
			if(ParticleColorEndAlphaRand.Checked == true)
			{
				ParticleColorEndAlphaBox.Value = (decimal)ize.Next(256);
			}
			if(ParticleColorBeginAlphaRand.Checked == true)
			{
				ParticleColorBeginAlphaBox.Value = (decimal)ize.Next(256);
			}
		}
		private void openSavedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openPTE = new OpenFileDialog();
			openPTE.Filter = "Particle Editor File (.pte) | *.pte";
			if (openPTE.ShowDialog() == DialogResult.OK)
			{
				FileStream fin = new FileStream(openPTE.FileName, FileMode.Open);
				engine.emitter = (Engine.Emitter)engine.XMLIO.Deserialize(fin);
				fin.Close();
			}
			ParticleAccelerationX.Value = (decimal)engine.emitter.acceleration.X;
			ParticleAccelerationY.Value = (decimal)engine.emitter.acceleration.Y;
			ParticleSizeBegin.Value = (decimal)engine.emitter.beginSize;
			EmitterDirectionBegin.Value = (decimal)engine.emitter.directionBegin;
			EmitterDirectionEnd.Value = (decimal)engine.emitter.directionEnd;
			ParticleColorEndRedTrack.Value = (int)engine.emitter.endColor.Red;
			ParticleColorEndRedBox.Value =  (decimal)engine.emitter.endColor.Red;
			ParticleColorEndGreenTrack.Value = (int)engine.emitter.endColor.Green;
			ParticleColorEndGreenBox.Value = (decimal)engine.emitter.endColor.Green;
			ParticleColorEndBlueTrack.Value = (int)engine.emitter.endColor.Blue;
			ParticleColorEndBlueBox.Value = (decimal)engine.emitter.endColor.Blue;
			ParticleColorEndAlphaTrack.Value = (int)engine.emitter.endColor.Alpha;
			ParticleColorEndAlphaBox.Value = (decimal)engine.emitter.endColor.Alpha;
			ParticleSizeEnd.Value = (decimal)engine.emitter.endSize;
			ParticleLifetimeEnd.Value = (decimal)engine.emitter.maxLifetime;
			ParticleLifetimeBegin.Value = (decimal)engine.emitter.minLifetime;
			ParticleNumber.Value = (decimal)engine.emitter.numParticles;
			EmitterPositionX.Value = (decimal)engine.emitter.position.X;
			EmitterPositionY.Value = (decimal)engine.emitter.position.Y;
			EmitterSizeX.Value = (decimal)engine.emitter.size.Height;
			EmitterSizeY.Value = (decimal)engine.emitter.size.Width;
			ParticleSpeed.Value = (decimal)engine.emitter.speed;
			ParticleColorBeginRedTrack.Value = (int)engine.emitter.startColor.Red;
			ParticleColorBeginRedBox.Value = (decimal)engine.emitter.startColor.Red;
			ParticleColorBeginGreenTrack.Value = (int)engine.emitter.startColor.Green;
			ParticleColorBeginGreenBox.Value = (decimal)engine.emitter.startColor.Green;
			ParticleColorBeginBlueTrack.Value = (int)engine.emitter.startColor.Blue;
			ParticleColorBeginBlueBox.Value = (decimal)engine.emitter.startColor.Blue;
			ParticleColorBeginAlphaTrack.Value = (int)engine.emitter.startColor.Alpha;
			ParticleColorBeginAlphaBox.Value = (decimal)engine.emitter.startColor.Alpha;
		}
		private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog savePTE = new SaveFileDialog();
			savePTE.Filter = "Particle Editor File (.pte) | *.pte";
			if (savePTE.ShowDialog() == DialogResult.OK)
			{
				StreamWriter fout = new StreamWriter(savePTE.FileName);

				engine.XMLIO.Serialize(fout, engine.emitter);
				fout.Close();
			}
		}

		private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog savePTE = new SaveFileDialog();
			savePTE.Filter = "Particle Editor Binary (.ptb) | *.pte";
			if (savePTE.ShowDialog() == DialogResult.OK)
			{
				BinaryWriter fout =
							new BinaryWriter(File.Open(savePTE.FileName, FileMode.Create));
				{
					if (ParticleSpeedConstant.Checked == false)
					{
						fout.Write((double)engine.emitter.acceleration.X);	// float = 4 (cast) 8
						fout.Write((double)engine.emitter.acceleration.Y);	// float = 4 (cast) 8
					}
					else
					{
						fout.Write(0.0); // Constant literals are double by default.
						fout.Write(0.0);
					}
					fout.Write(engine.emitter.beginSize);		// float = 4
					fout.Write(engine.emitter.directionBegin);	// float = 4
					fout.Write(engine.emitter.directionEnd);	// float = 4
					fout.Write(engine.emitter.endColor.Red);	// float = 4
					fout.Write(engine.emitter.endColor.Green);	// float = 4
					fout.Write(engine.emitter.endColor.Blue);	// float = 4
					fout.Write(engine.emitter.endColor.Alpha);	// float = 4
					if (ParticleSizeConstant.Checked == false)
						fout.Write(engine.emitter.endSize);			// float = 4
					else
						fout.Write(engine.emitter.beginSize);
					fout.Write(engine.emitter.maxLifetime);		// double = 8
					fout.Write(engine.emitter.minLifetime);		// double = 8
					fout.Write(engine.emitter.numParticles);	// int = 4
					fout.Write((double)engine.emitter.position.X);		// int = 4 (cast) 8
					fout.Write((double)engine.emitter.position.Y);		// int = 4 (cast) 8
					fout.Write(engine.emitter.size.Height);		// int = 4
					fout.Write(engine.emitter.size.Width);		// int = 4
					fout.Write(engine.emitter.speed);			// double = 8
					fout.Write(engine.emitter.startColor.Red);	// float = 4
					fout.Write(engine.emitter.startColor.Green);// float = 4
					fout.Write(engine.emitter.startColor.Blue);	// float = 4
					fout.Write(engine.emitter.startColor.Alpha);// float = 4
				}
				fout.Close();
			}
		}
		private void CheckAllColorRand_CheckedChanged(object sender, EventArgs e)
		{
			if (CheckAllColorRand.Checked == true)
			{
				ParticleColorBeginRedRand.Checked = true;
				ParticleColorBeginBlueRand.Checked = true;
				ParticleColorBeginGreenRand.Checked = true;
				ParticleColorBeginAlphaRand.Checked = true;
				//if (ParticleColorConstant.Checked == false)
				//{
					ParticleColorEndGreenRand.Checked = true;
					ParticleColorEndBlueRand.Checked = true;
					ParticleColorEndRedRand.Checked = true;
					ParticleColorEndAlphaRand.Checked = true;
				//}
			}
			else
			{
				ParticleColorBeginRedRand.Checked = false;
				ParticleColorBeginBlueRand.Checked = false;
				ParticleColorBeginGreenRand.Checked = false;
				ParticleColorBeginAlphaRand.Checked = false;
				//if (ParticleColorConstant.Checked == false)
				//{
					ParticleColorEndGreenRand.Checked = false;
					ParticleColorEndBlueRand.Checked = false;
					ParticleColorEndRedRand.Checked = false;
					ParticleColorEndAlphaRand.Checked = false;
				//}
			}
		}
#endregion


	}
}
