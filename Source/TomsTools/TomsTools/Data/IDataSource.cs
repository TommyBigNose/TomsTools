using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomsTools.Models;

namespace TomsTools.Data
{
	public interface IDataSource
	{
		IEnumerable<StringTemplate> GetStringTemplates();
	}
}
