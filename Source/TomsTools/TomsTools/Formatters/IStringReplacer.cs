using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomsTools.Formatters
{
	public interface IStringReplacer
	{
		bool CanReplace(string text, string oldCharacter, string newCharacter);
		string Replace(string text, string oldCharacter, string newCharacter);
	}
}
