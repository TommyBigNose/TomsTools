using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomsTools.Formatters
{
	public interface IStringReplacer
	{
		string Replace(string text, string oldCharacter, string newCharacter);
	}
}
