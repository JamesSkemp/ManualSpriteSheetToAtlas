using ManualSpriteSheetToAtlas.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualSpriteSheetToAtlas.Converters
{
	public class PhaserJsonConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			// Verify we're working with an AtlasDefinition type of object.
			return typeof(AtlasDefinition).IsAssignableFrom(objectType);
		}

		public override bool CanRead
		{
			get
			{
				// TODO allow reading at some point.
				return false;
			}
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			// Until CanRead is true this isn't needed.
			throw new NotImplementedException();
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			JToken t = JToken.FromObject(value);
			if (t.Type != JTokenType.Object)
			{
				t.WriteTo(writer);
				return;
			}

			var atlas = (AtlasDefinition)value;

			writer.Formatting = Formatting.Indented;

			writer.WriteStartObject();

			writer.WritePropertyName("frames");
			writer.WriteStartArray();

			foreach (var sprite in atlas.SpriteDefinitions)
			{
				writer.WriteStartObject();
				writer.WritePropertyName("filename");
				writer.WriteValue(sprite.Name);

				writer.WritePropertyName("frame");
				writer.WriteStartObject();
				writer.WritePropertyName("x");
				writer.WriteValue(sprite.X);
				writer.WritePropertyName("y");
				writer.WriteValue(sprite.Y);
				writer.WritePropertyName("w");
				writer.WriteValue(sprite.Width);
				writer.WritePropertyName("h");
				writer.WriteValue(sprite.Height);
				writer.WriteEndObject();

				writer.WritePropertyName("rotated");
				writer.WriteValue(false);
				writer.WritePropertyName("trimmed");
				writer.WriteValue(false);

				writer.WritePropertyName("spriteSourceSize");
				writer.WriteStartObject();
				writer.WritePropertyName("x");
				writer.WriteValue(0);
				writer.WritePropertyName("y");
				writer.WriteValue(0);
				writer.WritePropertyName("w");
				writer.WriteValue(sprite.Width);
				writer.WritePropertyName("h");
				writer.WriteValue(sprite.Height);
				writer.WriteEndObject();

				writer.WritePropertyName("sourceSize");
				writer.WriteStartObject();
				writer.WritePropertyName("w");
				writer.WriteValue(sprite.Width);
				writer.WritePropertyName("h");
				writer.WriteValue(sprite.Height);
				writer.WriteEndObject();

				writer.WriteEndObject();
			}
			writer.WriteEndArray();

			writer.WritePropertyName("meta");
			writer.WriteStartObject();

			writer.WritePropertyName("app");
			writer.WriteValue("https://github.com/JamesSkemp/ManualSpriteSheetToAtlas");
			writer.WritePropertyName("version");
			writer.WriteValue(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
			writer.WritePropertyName("image");
			writer.WriteValue(atlas.OriginalImageName);
			writer.WritePropertyName("format");
			switch (atlas.OriginalImageFormat)
			{
				case System.Drawing.Imaging.PixelFormat.Format32bppArgb:
					writer.WriteValue("RGBA8888");
					break;

				// TODO define additional options here as needed

				default:
					writer.WriteValue(atlas.OriginalImageFormat);
					break;
			}

			writer.WritePropertyName("size");
			writer.WriteStartObject();
			writer.WritePropertyName("w");
			writer.WriteValue(atlas.OriginalImageWidth);
			writer.WritePropertyName("h");
			writer.WriteValue(atlas.OriginalImageHeight);
			writer.WriteEndObject();
			writer.WritePropertyName("scale");
			writer.WriteValue("1");

			writer.WriteEndObject();

			writer.WriteEndObject();
		}
	}
}
