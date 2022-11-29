using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomsTools.Formatters
{
	public interface IStringFormatter
	{
		bool CanFormat(string text);
		string Format(string text);
	}
}
