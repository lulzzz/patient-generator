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
 * Date: 2016-2-28
 */

using PatientGenerator.Core;
using PatientGenerator.Core.Model.Common;
using PatientGenerator.Core.Model.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientGenerator.FHIR
{
	/// <summary>
	/// Represents a FHIR sender service.
	/// </summary>
	/// <seealso cref="PatientGenerator.Core.IFhirSenderService" />
	public class FhirSenderService : IFhirSenderService
	{
		/// <summary>
		/// Sends the specified options.
		/// </summary>
		/// <param name="options">The options.</param>
		public void Send(Demographic options)
		{
			var patient = FhirUtility.GenerateCandidateRegistry(options);

			FhirUtility.SendFhirMessages(patient);
		}

		/// <summary>
		/// Sends the specified patients.
		/// </summary>
		/// <param name="patients">The patients.</param>
		public void Send(IEnumerable<Patient> patients)
		{
			var messages = patients.Select(patient => FhirUtility.GenerateCandidateRegistry(patient, new Core.Model.Metadata
			{
				AssigningAuthority = "1.3.6.1.4.1.33349.3.1.5.102.4.20",
				ReceivingApplication = "OpenIZ",
				ReceivingFacility = "OpenIZ",
				SendingApplication = "Test",
				SendingFacility = "Test"
			}))
									.ToList();

			messages.Select(FhirUtility.SendFhirMessages);
		}

		/// <summary>
		/// Sends the specified patient.
		/// </summary>
		/// <param name="patient">The patient.</param>
		public void Send(Patient patient)
		{
			var message = FhirUtility.GenerateCandidateRegistry(patient, new Core.Model.Metadata
			{
				AssigningAuthority = "1.3.6.1.4.1.33349.3.1.5.9.2.10000",
				ReceivingApplication = "OpenIZ",
				ReceivingFacility = "OpenIZ",
				SendingApplication = "Test",
				SendingFacility = "Test"
			});

			FhirUtility.SendFhirMessages(message);
		}

		/// <summary>
		/// send as an asynchronous operation.
		/// </summary>
		/// <param name="options">The options.</param>
		/// <returns>Task.</returns>
		public async Task SendAsync(Demographic options)
		{
			await Task.Factory.StartNew(() =>
			{
				this.Send(options);
			});
		}

		/// <summary>
		/// Sends the asynchronous.
		/// </summary>
		/// <param name="patients">The patients.</param>
		/// <returns>Task.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public Task SendAsync(IEnumerable<Patient> patients)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Sends the asynchronous.
		/// </summary>
		/// <param name="patient">The patient.</param>
		/// <returns>Task.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public Task SendAsync(Patient patient)
		{
			throw new NotImplementedException();
		}
	}
}