﻿namespace BookstoreLibrary.Model
{
	public class Publisher
	{
		public string PublishersName { get; set; }
		public string PhoneNumber { get; set; }

		public Publisher(string publishersName, string phoneNumber)
		{
			PublishersName = publishersName;
			PhoneNumber = phoneNumber;
		}

		public override string ToString()
		{
			return $"Publisher: {PublishersName}, phone numer: {PhoneNumber}\n";
		}
	}
}
