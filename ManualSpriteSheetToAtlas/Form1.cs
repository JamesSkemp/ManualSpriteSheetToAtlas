using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManualSpriteSheetToAtlas
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			if (openFileDialog1.ShowDialog() != DialogResult.OK)
			{
				MessageBox.Show("You must select an image to continue.");

				if (openFileDialog1.ShowDialog() != DialogResult.OK)
				{
					// The user has failed twice; quit.
					Application.Exit();
				}
			}

			var imageFile = Image.FromFile(openFileDialog1.FileName);

			if (imageFile != null)
			{
				panelOriginalImage.BackgroundImage = imageFile;
			}
		}
	}
}
