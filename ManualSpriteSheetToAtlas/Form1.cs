﻿using ManualSpriteSheetToAtlas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
		/// <summary>
		/// When not explicitly named, prefix to use when automatically giving a sprite a name.
		/// </summary>
		private string namingPrefix;
		/// <summary>
		/// Number of sprites defined. Used when automatically giving a sprite a name.
		/// </summary>
		private int definedSprites;

		/// <summary>
		/// Original image the user selected.
		/// </summary>
		private Image originalImage;
		/// <summary>
		/// File name of the original image, used when saving the atlas file.
		/// </summary>
		private string originalImageFileName;
		/// <summary>
		/// Image displayed by the main display.
		/// </summary>
		private Bitmap displayedImage;
		/// <summary>
		/// Image displayed in the preview when moving the cursor. Provides a zoomed-in preview to aid with selection.
		/// </summary>
		private Bitmap croppedImage;

		private Point pictureCursorPosition;

		private Rectangle sourceRectangle;
		private Rectangle zoomRectangle;

		private int zoomFactor = 1;
		/// <summary>
		/// Cursor position, with zoom factor taken into account.
		/// </summary>
		private Point finalCursorPosition;

		/// <summary>
		/// There are unsaved changes.
		/// </summary>
		private bool hasUnsavedChanges;

		/// <summary>
		/// The user is actively drawing a rectangle.
		/// </summary>
		private bool isDrawing;
		/// <summary>
		/// Point user started drawing on the image, based upon original image.
		/// </summary>
		private Point drawingStart;
		/// <summary>
		/// Point user stopped drawing on the image, based upon original image.
		/// </summary>
		private Point drawingEnd;
		/// <summary>
		/// Temporary point for drawing.
		/// </summary>
		private Point drawingTempPoint;
		/// <summary>
		/// Rectangle of the user's current drawing.
		/// </summary>
		private Rectangle currentDrawingRectangle;

		private AtlasDefinition atlasDefinitions;

		public Form1()
		{
			InitializeComponent();

			setupInterfaceDefaults();

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

		/// <summary>
		/// Update the interface with a few defaults.
		/// </summary>
		private void setupInterfaceDefaults()
		{
			// We can't zoom out by default, since the factor will be set to 1.
			outToolStripMenuItem.Enabled = false;
			// Clear the text we drop into place to help with development.
			toolStripStatusLabelCursor.Text = toolStripStatusLabelImageSize.Text
				= string.Empty;

			toolStripStatusLabelZoom.Text = string.Format("Zoom: {0}", zoomFactor);

			namingPrefix = ConfigurationManager.AppSettings["DefaultNamingPrefix"] ?? "";

			// They can't save until they've made changes.
			saveToolStripMenuItem.Enabled = false;
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!hasUnsavedChanges || MessageBox.Show("All unsaved progress will be lost.", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
					originalImageFileName = Path.GetFileName(openFileDialog1.FileName);

					imageLoaded = displayMainImage();

					// They've loaded an image, so clear the output if there is any.
					textBoxOutput.Text = "";
					definedSprites = 0;
					atlasDefinitions = new AtlasDefinition() {
						OriginalImageName = originalImageFileName,
						OriginalImageWidth = originalImage.Width,
						OriginalImageHeight = originalImage.Height,
						OriginalImageFormat = originalImage.PixelFormat
					};
					hasUnsavedChanges = false;
					saveToolStripMenuItem.Enabled = false;

					newImage.Dispose();
				}
			}

			return imageLoaded;
		}

		/// <summary>
		/// Displays the main image.
		/// </summary>
		/// <returns>True if the image is displayed.</returns>
		private bool displayMainImage()
		{
			var imageDisplayed = false;

			if (originalImage != null)
			{
				displayedImage = new Bitmap(originalImage, originalImage.Width * zoomFactor, originalImage.Height * zoomFactor);

				pictureBoxOriginalImage.BackgroundImage = displayedImage;
				pictureBoxOriginalImage.Size = displayedImage.Size;

				pictureBoxOriginalImage.Invalidate();

				toolStripStatusLabelImageSize.Text = string.Format("Image size: {0}", originalImage.Size.ToString());

				imageDisplayed = true;
			}

			return imageDisplayed;
		}

		/// <summary>
		/// Update the zoomed-in view of the user's cursor.
		/// </summary>
		private void updateZoomView()
		{
			if (croppedImage != null)
			{
				pictureCursorPosition = pictureBoxOriginalImage.PointToClient(Cursor.Position);

				finalCursorPosition.X = pictureCursorPosition.X / zoomFactor;
				finalCursorPosition.Y = pictureCursorPosition.Y / zoomFactor;

				toolStripStatusLabelCursor.Text = string.Format("Cursor: {0}", finalCursorPosition);

				// Update the zoom panel, which is 250 x 250, so display 10x10 around cursor.
				sourceRectangle = new Rectangle(finalCursorPosition.X, finalCursorPosition.Y, 10, 10);

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
			if (e.Button == MouseButtons.Right && isDrawing)
			{
				// We're drawing and they used the right mouse button. Cancel the drawing.
				drawingStart = new Point();
				isDrawing = false;
				currentDrawingRectangle = new Rectangle();
				Refresh();
				return;
			}

			drawingStart = getDrawingCursor();
			isDrawing = true;
			currentDrawingRectangle = new Rectangle();
		}

		private void pictureBoxOriginalImage_MouseMove(object sender, MouseEventArgs e)
		{
			updateZoomView();
			if (isDrawing)
			{
				drawingTempPoint = getDrawingCursor();
				updateCurrentDrawingRectangle();
				
				Refresh();
			}
		}

		private void pictureBoxOriginalImage_MouseUp(object sender, MouseEventArgs e)
		{
			// They've finished drawing, so save the sprite defintion.
			if (isDrawing)
			{
				drawingEnd = getDrawingCursor();

				saveDrawing();

				isDrawing = false;
			}
		}

		private void pictureBoxOriginalImage_Paint(object sender, PaintEventArgs e)
		{
			// The rectangle is drawn here.
			using (var pen = new Pen(Color.Red, 1))
			{
				e.Graphics.DrawRectangle(pen, currentDrawingRectangle);
			}
		}

		private void pictureBoxOriginalImage_MouseEnter(object sender, EventArgs e)
		{
			updateZoomView();
		}

		private void pictureBoxOriginalImage_MouseLeave(object sender, EventArgs e)
		{
			panelZoom.BackgroundImage = null;
		}

		/// <summary>
		/// Zoom in on the original image.
		/// </summary>
		private void inToolStripMenuItem_Click(object sender, EventArgs e)
		{
			zoomFactor += 1;
			zoomOriginal();
		}

		/// <summary>
		/// Zoom out of the original image.
		/// </summary>
		private void outToolStripMenuItem_Click(object sender, EventArgs e)
		{
			zoomFactor -= 1;
			if (zoomFactor < 1)
			{
				zoomFactor = 1;
			}
			zoomOriginal();
		}

		/// <summary>
		/// Update the original image with the current zoom factor.
		/// </summary>
		private void zoomOriginal()
		{
			toolStripStatusLabelZoom.Text = string.Format("Zoom: {0}", zoomFactor);

			// Reset the rectangle so it doesn't display.
			currentDrawingRectangle = new Rectangle();

			displayMainImage();

			// You can't zoom out any further than the original size.
			outToolStripMenuItem.Enabled = zoomFactor > 1;
		}

		/// <summary>
		/// Save the currently drawn points.
		/// </summary>
		/// <returns>True if data is saved.</returns>
		private bool saveDrawing()
		{
			bool dataSaved = false;

			if (
				(!drawingStart.IsEmpty || !drawingEnd.IsEmpty)
				&& drawingStart != drawingEnd
				)
			{
				fixDrawingPoints();
				normalizePoints();

				definedSprites++;
				// TODO eventually have the user be able to set this.
				string spriteName = string.Format("{0}{1}", namingPrefix, definedSprites);
				textBoxOutput.Text += string.Format("{0}:{1} x {2}{3}", spriteName, drawingStart, drawingEnd, Environment.NewLine);

				// Add our new point to 
				atlasDefinitions.SpriteDefinitions.Add(new SpriteDefinition(
					definedSprites, spriteName, drawingStart.X, drawingStart.Y
					// Width and height of the sprite based upon starting/ending points.
					, drawingEnd.X - drawingStart.X, drawingEnd.Y - drawingStart.Y));

				hasUnsavedChanges = true;
				saveToolStripMenuItem.Enabled = true;

				drawingStart = Point.Empty;
				drawingEnd = Point.Empty;
			}

			return dataSaved;
		}

		/// <summary>
		/// Fix the drawing points so they don't sit outside the bounds of the image.
		/// </summary>
		private void fixDrawingPoints()
		{
			// The X and Y positions can't be less than 0,0.
			if (drawingStart.X < 0)
			{
				drawingStart.X = 0;
			}
			if (drawingStart.Y < 0)
			{
				drawingStart.Y = 0;
			}
			if (drawingEnd.X < 0)
			{
				drawingEnd.X = 0;
			}
			if (drawingEnd.Y < 0)
			{
				drawingEnd.Y = 0;
			}

			// The X and Y positions can't be larger than the image (-1 because zero-based).
			if (drawingStart.X >= originalImage.Size.Width)
			{
				drawingStart.X = originalImage.Size.Width - 1;
			}
			if (drawingStart.Y >= originalImage.Size.Height)
			{
				drawingStart.Y = originalImage.Size.Height - 1;
			}
			if (drawingEnd.X >= originalImage.Size.Width)
			{
				drawingEnd.X = originalImage.Size.Width - 1;
			}
			if (drawingEnd.Y >= originalImage.Size.Height)
			{
				drawingEnd.Y = originalImage.Size.Height - 1;
			}
		}

		/// <summary>
		/// Makes sure the starting point is closer to {0, 0} than the ending point.
		/// </summary>
		private void normalizePoints()
		{
			// The X coordinate should be closer to the origin.
			if (drawingStart.X > drawingEnd.X)
			{
				int tempVariable = drawingStart.X;
				drawingStart.X = drawingEnd.X;
				drawingEnd.X = tempVariable;
			}

			// The Y coordinate should be closer to the origin.
			if (drawingStart.Y > drawingEnd.Y)
			{
				int tempVariable = drawingStart.Y;
				drawingStart.Y = drawingEnd.Y;
				drawingEnd.Y = tempVariable;
			}
		}

		/// <summary>
		/// Gets the position of the cursor relative to the original image.
		/// </summary>
		/// <returns>Cursor position within original image, accounting for zoom.</returns>
		private Point getDrawingCursor()
		{
			Point cursor = Point.Empty;

			cursor = pictureBoxOriginalImage.PointToClient(Cursor.Position);
			cursor.X /= zoomFactor;
			cursor.Y /= zoomFactor;

			return cursor;
		}

		/// <summary>
		/// Update the rectangle used for the current drawing around a sprite.
		/// </summary>
		private void updateCurrentDrawingRectangle()
		{
			// We need to define a starting point and then a width. This logic makes sure the starting point is closest to the origin.
			if (drawingStart.X < drawingTempPoint.X)
			{
				currentDrawingRectangle.X = drawingStart.X;
				currentDrawingRectangle.Width = drawingTempPoint.X - drawingStart.X;
			}
			else if (drawingStart.X > drawingTempPoint.X)
			{
				currentDrawingRectangle.X = drawingTempPoint.X;
				currentDrawingRectangle.Width = drawingStart.X - drawingTempPoint.X;
			}
			else
			{
				currentDrawingRectangle.X = drawingStart.X;
				currentDrawingRectangle.Width = 0;
			}

			if (drawingStart.Y < drawingTempPoint.Y)
			{
				currentDrawingRectangle.Y = drawingStart.Y;
				currentDrawingRectangle.Height = drawingTempPoint.Y - drawingStart.Y;
			}
			else if (drawingStart.Y > drawingTempPoint.Y)
			{
				currentDrawingRectangle.Y = drawingTempPoint.Y;
				currentDrawingRectangle.Height = drawingStart.Y - drawingTempPoint.Y;
			}
			else
			{
				currentDrawingRectangle.Y = drawingStart.Y;
				currentDrawingRectangle.Height = 0;
			}

			currentDrawingRectangle.X *= zoomFactor;
			currentDrawingRectangle.Y *= zoomFactor;
			currentDrawingRectangle.Width *= zoomFactor;
			currentDrawingRectangle.Height *= zoomFactor;
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!atlasDefinitions.SpriteDefinitions.Any())
			{
				// There's nothing to save. We shouldn't hit this circumstance, but in case we do, return.
				return;
			}

			var dataSaved = false;

			using (var saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Filter = "Phaser JSON|*.json";
				saveFileDialog.Title = "Save Data";
				saveFileDialog.ShowDialog();

				if (saveFileDialog.FileName != "")
				{
					string output = atlasDefinitions.SerializeToPhaserJson();

					if (!string.IsNullOrWhiteSpace(output))
					{
						File.WriteAllText(saveFileDialog.FileName, output);
						dataSaved = true;
						hasUnsavedChanges = false;
					}
				}
			}

			if (!dataSaved)
			{
				MessageBox.Show("There was an error saving. Please try again.");
			}
		}
	}
}
