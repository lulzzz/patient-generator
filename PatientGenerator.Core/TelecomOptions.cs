﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientGenerator.Core
{
	public class TelecomOptions
	{
		public TelecomOptions()
		{

		}

		public List<string> PhoneNumbers { get; set; }

		public List<string> EmailAddresses { get; set; }
	}
}
