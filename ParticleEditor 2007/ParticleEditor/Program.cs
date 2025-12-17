

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
//using Microsoft.Samples.DirectX.UtilityToolkit;

namespace ParticleEditor
{
    static class Program //: IFrameworkCallback, IDeviceCreation
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Form1());
			}
		}
    }
}