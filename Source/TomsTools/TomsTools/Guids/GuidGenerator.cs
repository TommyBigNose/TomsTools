﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomsTools.Guids
{
	public class GuidGenerator : IGuidGenerator
	{
		public Guid GenerateGuid()
		{
			return Guid.NewGuid();
		}
	}
}
