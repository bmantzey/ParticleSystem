using System;
using System.Collections.Generic;
using System.Text;

namespace ParticleEditor
{
	class ParticleSystem
	{

		public ParticleEffect(int sizeX, int sizeY, Canvas particleCanvas, Random random, double particleSpeed, int numberOfParticles)
        {
            canvas = particleCanvas;
            width= canvas.Width;
            maxX = width - sizeX;
            maxY = canvas.Height - sizeY;
            particleWidth = sizeX;
            particleHeight = sizeY;
            rand = random;
            speed = particleSpeed;
            numParticles = numberOfParticles;
            x = new int[numParticles];
            y = new int[numParticles];
            direction = new double[numParticles];
            angularVelocity = new double[numParticles];
            color = new int[numParticles];
            randData = new byte[canvas.Width / 4];
            rand.NextBytes(randData);
            
            
            //Assign colors and starting parameters to particles
            for(int i=0; i<numParticles; i++)
            {
                x[i] = rand.Next(maxX);
                y[i] = rand.Next(maxY);
                
                switch(i % 5)
                {
                    case 0:
                        color[i] = Color.Purple.ToArgb();
                        break;
                    case 1:
                        color[i] = Color.LightGreen.ToArgb();
                        break;
                    case 2:
                        color[i] = Color.Pink.ToArgb();
                        break;
                    case 3:
                        color[i] = Color.CornflowerBlue.ToArgb();
                        break;
                    case 4:
                        color[i] = Color.GhostWhite.ToArgb();
                        break;
                }
                angularVelocity[i] = 0;
                direction[i] = (rand.NextDouble() * Math.PI * 2.0) - Math.PI;
            }
            
        }

	}
}
