using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TomsTools.Formatters
{
	public class JsonStringFormatter : IStringFormatter
	{
		public bool CanFormat(string text)
		{
			bool canFormat = true;

			try
			{
				var obj = JsonSerializer.Deserialize<object>(text)!;
			}
			catch
			{
				canFormat = false;
			}

			return canFormat;
		}

		public string Format(string text)
		{
			try
			{
				var obj = JsonSerializer.Deserialize<object>(text)!;

				JsonSerializerOptions opt = new JsonSerializerOptions()	{ WriteIndented = true };
				string jsonFormatted = JsonSerializer.Serialize(obj, obj.GetType(), opt);

				return jsonFormatted;
			}
			catch
			{
				string message = "Current text in clipboard is not JSON";
				throw new ArgumentException(message);
			}
		}
	}
}
