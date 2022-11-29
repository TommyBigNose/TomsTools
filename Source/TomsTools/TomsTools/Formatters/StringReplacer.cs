using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomsTools.Formatters
{
	public class StringReplacer : IStringReplacer
	{
		public bool CanReplace(string text, string oldCharacter, string newCharacter)
		{
			return (text != null && !string.IsNullOrEmpty(oldCharacter) && newCharacter != null);
		}

		public string Replace(string text, string oldCharacter, string newCharacter)
		{
			return text.Replace(oldCharacter, newCharacter);
		}
	}
}
