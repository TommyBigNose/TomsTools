using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomsTools.Templates
{
	public interface ITemplateSelector
	{
		string GetTemplate(int templateId);
	}
}
