﻿/*
 * Copyright 2016-2017 Mohawk College of Applied Arts and Technology
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you
 * may not use this file except in compliance with the License. You may
 * obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 *
 * User: Nityan
 * Date: 2016-2-15
 */

using System.Collections.Generic;
using System.Xml.Serialization;

namespace PatientGenerator.HL7v2.Configuration
{
	/// <summary>
	/// Represents an HL7v2 configuration section.
	/// </summary>
	public class HL7v2ConfigurationSection
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HL7v2ConfigurationSection"/> class.
		/// </summary>
		public HL7v2ConfigurationSection()
		{
			Endpoints = new List<LlpEndpoint>();
		}

		/// <summary>
		/// Gets or sets the endpoints.
		/// </summary>
		/// <value>The endpoints.</value>
		[XmlElement("endpoints")]
		public List<LlpEndpoint> Endpoints { get; set; }
	}
}