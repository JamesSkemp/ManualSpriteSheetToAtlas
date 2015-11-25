namespace ManualSpriteSheetToAtlas
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panelOriginalImage = new System.Windows.Forms.Panel();
			this.pictureBoxOriginalImage = new System.Windows.Forms.PictureBox();
			this.panelZoom = new System.Windows.Forms.Panel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.inToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.outToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelCursor = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabelImageSize = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabelZoom = new System.Windows.Forms.ToolStripStatusLabel();
			this.panelOriginalImage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Image Files(*.jpg; *.png; *.gif; *.bmp)| *.jpg; *.png; *.gif; *.bmp";
			this.openFileDialog1.Title = "Select a sprite sheet to load";
			// 
			// panelOriginalImage
			// 
			this.panelOriginalImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelOriginalImage.AutoScroll = true;
			this.panelOriginalImage.BackColor = System.Drawing.Color.Transparent;
			this.panelOriginalImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.panelOriginalImage.Controls.Add(this.pictureBoxOriginalImage);
			this.panelOriginalImage.Cursor = System.Windows.Forms.Cursors.Cross;
			this.panelOriginalImage.Location = new System.Drawing.Point(12, 43);
			this.panelOriginalImage.Name = "panelOriginalImage";
			this.panelOriginalImage.Size = new System.Drawing.Size(930, 746);
			this.panelOriginalImage.TabIndex = 0;
			// 
			// pictureBoxOriginalImage
			// 
			this.pictureBoxOriginalImage.BackColor = System.Drawing.Color.White;
			this.pictureBoxOriginalImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.pictureBoxOriginalImage.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxOriginalImage.Name = "pictureBoxOriginalImage";
			this.pictureBoxOriginalImage.Size = new System.Drawing.Size(930, 650);
			this.pictureBoxOriginalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBoxOriginalImage.TabIndex = 5;
			this.pictureBoxOriginalImage.TabStop = false;
			this.pictureBoxOriginalImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxOriginalImage_Paint);
			this.pictureBoxOriginalImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxOriginalImage_MouseDown);
			this.pictureBoxOriginalImage.MouseEnter += new System.EventHandler(this.pictureBoxOriginalImage_MouseEnter);
			this.pictureBoxOriginalImage.MouseLeave += new System.EventHandler(this.pictureBoxOriginalImage_MouseLeave);
			this.pictureBoxOriginalImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxOriginalImage_MouseMove);
			this.pictureBoxOriginalImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxOriginalImage_MouseUp);
			// 
			// panelZoom
			// 
			this.panelZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panelZoom.BackColor = System.Drawing.Color.White;
			this.panelZoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.panelZoom.Location = new System.Drawing.Point(948, 43);
			this.panelZoom.Name = "panelZoom";
			this.panelZoom.Size = new System.Drawing.Size(250, 250);
			this.panelZoom.TabIndex = 1;
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.zoomToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1210, 42);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(269, 38);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Location = new System.Drawing.Point(948, 299);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(250, 490);
			this.panel1.TabIndex = 3;
			// 
			// zoomToolStripMenuItem
			// 
			this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inToolStripMenuItem,
            this.outToolStripMenuItem});
			this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
			this.zoomToolStripMenuItem.Size = new System.Drawing.Size(90, 38);
			this.zoomToolStripMenuItem.Text = "Zoom";
			// 
			// inToolStripMenuItem
			// 
			this.inToolStripMenuItem.Name = "inToolStripMenuItem";
			this.inToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
			this.inToolStripMenuItem.Size = new System.Drawing.Size(269, 38);
			this.inToolStripMenuItem.Text = "In";
			this.inToolStripMenuItem.Click += new System.EventHandler(this.inToolStripMenuItem_Click);
			// 
			// outToolStripMenuItem
			// 
			this.outToolStripMenuItem.Name = "outToolStripMenuItem";
			this.outToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
			this.outToolStripMenuItem.Size = new System.Drawing.Size(269, 38);
			this.outToolStripMenuItem.Text = "Out";
			this.outToolStripMenuItem.Click += new System.EventHandler(this.outToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCursor,
            this.toolStripStatusLabelImageSize,
            this.toolStripStatusLabelZoom});
			this.statusStrip1.Location = new System.Drawing.Point(0, 802);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1210, 37);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabelCursor
			// 
			this.toolStripStatusLabelCursor.Name = "toolStripStatusLabelCursor";
			this.toolStripStatusLabelCursor.Size = new System.Drawing.Size(80, 33);
			this.toolStripStatusLabelCursor.Text = "cursor";
			// 
			// toolStripStatusLabelImageSize
			// 
			this.toolStripStatusLabelImageSize.Name = "toolStripStatusLabelImageSize";
			this.toolStripStatusLabelImageSize.Size = new System.Drawing.Size(55, 33);
			this.toolStripStatusLabelImageSize.Text = "size";
			// 
			// toolStripStatusLabelZoom
			// 
			this.toolStripStatusLabelZoom.Name = "toolStripStatusLabelZoom";
			this.toolStripStatusLabelZoom.Size = new System.Drawing.Size(75, 33);
			this.toolStripStatusLabelZoom.Text = "zoom";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1210, 839);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panelZoom);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.panelOriginalImage);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Manual Sprite Sheet to Atlas Creator";
			this.panelOriginalImage.ResumeLayout(false);
			this.panelOriginalImage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Panel panelOriginalImage;
		private System.Windows.Forms.Panel panelZoom;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBoxOriginalImage;
		private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem inToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem outToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCursor;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelImageSize;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelZoom;
	}
}

