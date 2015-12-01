using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualSpriteSheetToAtlas
{
	/// <summary>
	/// Definition of an individual sprite.
	/// </summary>
	public class SpriteDefinition
	{
		public string Name { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }

		public SpriteDefinition()
		{
		}

		public SpriteDefinition(string name, int x, int y, int width, int height) : base()
		{
			this.Name = name;
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
		}
	}
}
