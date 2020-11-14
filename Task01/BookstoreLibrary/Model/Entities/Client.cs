using System.Collections.Generic;

namespace BookstoreLibrary.Model.Entities
{
	public class Client
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PESEL { get; set; }
		public string PhoneNumber { get; set; }

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
			int hashCode = -1822206648;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PESEL);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PhoneNumber);
			return hashCode;
		}


		public override string ToString()
		{
			return $"Client: {FirstName} {LastName}, PESEL: {PESEL}, phone number: {PhoneNumber}\n";
		}
	}
}
