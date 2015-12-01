using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualSpriteSheetToAtlas.Models
{
	/// <summary>
	/// Defines a new atlas for a sprite sheet.
	/// </summary>
	public class AtlasDefinition
	{
		/// <summary>
		/// Individual sprites within the image.
		/// </summary>
		public List<SpriteDefinition> SpriteDefinitions { get; set; }

		public AtlasDefinition()
		{
			SpriteDefinitions = new List<SpriteDefinition>();
		}
	}
}
