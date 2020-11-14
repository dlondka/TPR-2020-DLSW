using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreLibrary.Model.Entities
{
	public class Client
	{
		private string FirstName { get; set; }
		private string LastName { get; set; }
		private string PESEL { get; set; }
		private string PhoneNumber { get; set; }

		public Client(string firstName, string lastName, string PESEL, string phoneNumber)
		{
			FirstName = firstName;
			LastName = lastName;
			this.PESEL = PESEL;
			PhoneNumber = phoneNumber;
		}

		public override bool Equals(object obj)
		{
			return obj is Client client &&
						 FirstName == client.FirstName &&
						 LastName == client.LastName &&
						 PESEL == client.PESEL &&
						 PhoneNumber == client.PhoneNumber;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return $"Client: {FirstName} {LastName}, PESEL: {PESEL}, phone number: {PhoneNumber}";
		}
	}
}
