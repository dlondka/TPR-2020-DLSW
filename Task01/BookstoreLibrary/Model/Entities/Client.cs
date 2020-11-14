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
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return $"Client: {FirstName} {LastName}, PESEL: {PESEL}, phone number: {PhoneNumber}\n";
		}
	}
}
