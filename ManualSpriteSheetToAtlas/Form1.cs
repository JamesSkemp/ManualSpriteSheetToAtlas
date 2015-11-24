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
		private Image originalImage;

		public Form1()
		{
			InitializeComponent();

			if (!selectFile())
			{
				MessageBox.Show("You must select an image to continue.");

				if (!selectFile())
				{
					// The user has failed twice; quit.
					Application.Exit();
				}
			}
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("All unsaved progress will be lost.", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				selectFile();
			}
		}

		/// <summary>
		/// Allow the user to select a file.
		/// </summary>
		/// <returns>True if the user selected a file.</returns>
		private bool selectFile()
		{
			var imageLoaded = false;

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				var newImage = Image.FromFile(openFileDialog1.FileName);

				if (newImage != null)
				{
					originalImage = (Image)newImage.Clone();

					pictureBoxOriginalImage.BackgroundImage = originalImage;
					pictureBoxOriginalImage.Size = originalImage.Size;
					imageLoaded = true;
				}
			}

			return imageLoaded;
		}

		private void pictureBoxOriginalImage_MouseDown(object sender, MouseEventArgs e)
		{
			// TODO start drawing our rectangle here
		}

		private void pictureBoxOriginalImage_MouseMove(object sender, MouseEventArgs e)
		{
			// TODO continue drawing our rectangle here, if they started drawing
		}

		private void pictureBoxOriginalImage_MouseUp(object sender, MouseEventArgs e)
		{
			// TODO finish drawing our rectangle here, if they started

		}

		private void pictureBoxOriginalImage_Paint(object sender, PaintEventArgs e)
		{
			// TODO drawi rectangle here

		}

		private void pictureBoxOriginalImage_MouseEnter(object sender, EventArgs e)
		{
			// TODO update preview/zoom display

		}

		private void pictureBoxOriginalImage_MouseLeave(object sender, EventArgs e)
		{
			// TODO update preview/zoom display

		}
	}
}
