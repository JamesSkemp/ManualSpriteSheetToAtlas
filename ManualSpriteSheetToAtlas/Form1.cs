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
		private Bitmap zoomedImage;
		private Bitmap croppedImage;
		private Point pictureCursorPosition;

		private Rectangle sourceRectangle;
		private Rectangle zoomRectangle;

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

			zoomRectangle = new Rectangle(0, 0, panelZoom.Width, panelZoom.Height);
			croppedImage = new Bitmap(zoomRectangle.Width, zoomRectangle.Height);
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

					zoomedImage = new Bitmap(panelZoom.Width, panelZoom.Height, originalImage.PixelFormat);

					pictureBoxOriginalImage.BackgroundImage = originalImage;
					pictureBoxOriginalImage.Size = originalImage.Size;
					imageLoaded = true;
				}
			}

			return imageLoaded;
		}

		/// <summary>
		/// Update the zoomed-in view of the user's cursor.
		/// </summary>
		private void updateZoomView()
		{
			if (zoomedImage != null)
			{
				pictureCursorPosition = pictureBoxOriginalImage.PointToClient(Cursor.Position);

				// Update the zoom panel, which is 250 x 250, so display 10x10 around cursor.
				sourceRectangle = new Rectangle(pictureCursorPosition.X, pictureCursorPosition.Y, 10, 10);

				using (var graphics = Graphics.FromImage(croppedImage))
				{
					graphics.Clear(Color.White);
					graphics.DrawImage(originalImage, zoomRectangle, sourceRectangle, GraphicsUnit.Pixel);
				}

				panelZoom.BackgroundImage = croppedImage;
				panelZoom.Invalidate();
			}
		}

		private void pictureBoxOriginalImage_MouseDown(object sender, MouseEventArgs e)
		{
			// TODO start drawing our rectangle here
		}

		private void pictureBoxOriginalImage_MouseMove(object sender, MouseEventArgs e)
		{
			// TODO continue drawing our rectangle here, if they started drawing
			updateZoomView();
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
			updateZoomView();
		}

		private void pictureBoxOriginalImage_MouseLeave(object sender, EventArgs e)
		{
			panelZoom.BackgroundImage = null;
		}
	}
}
