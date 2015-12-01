using ManualSpriteSheetToAtlas.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualSpriteSheetToAtlas.Converters
{
	public class PhaserJsonConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
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
			Console.WriteLine(value);
			Console.WriteLine(t);
			Console.WriteLine(t.Type);
			t.WriteTo(writer);
		}
	}
}
