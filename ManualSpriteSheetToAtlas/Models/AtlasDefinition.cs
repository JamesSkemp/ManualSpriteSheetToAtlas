using ManualSpriteSheetToAtlas.Converters;
using Newtonsoft.Json;
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
		/// Name of the original file name.
		/// </summary>
		public string OriginalImageName { get; set; }
		/// <summary>
		/// Width of the original image.
		/// </summary>
		public int OriginalImageWidth { get; set; }
		/// <summary>
		/// Height of the original image.
		/// </summary>
		public int OriginalImageHeight { get; set; }
		/// <summary>
		/// Format of the original image.
		/// </summary>
		public System.Drawing.Imaging.PixelFormat OriginalImageFormat { get; set; }
		/// <summary>
		/// Individual sprites within the image.
		/// </summary>
		public List<SpriteDefinition> SpriteDefinitions { get; set; }

		public AtlasDefinition()
		{
			SpriteDefinitions = new List<SpriteDefinition>();
		}

		public string SerializeToPhaserJson()
		{
			string output = "";

			output = JsonConvert.SerializeObject(this, Formatting.Indented, new PhaserJsonConverter());

			return output;
		}
	}
}
