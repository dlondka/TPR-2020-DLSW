using System;

namespace BookstoreLibrary
{
	public class RandomDataFiller : IDataFiller
	{
		private readonly string[] FirstNames = { "Ellie", "Luis", "Rachel", "Jud", "Gage" };
		private readonly string[] LastNames = { "Doe", "Snow", "Sanchez", "Smith", "Butler" };
		private readonly string[] PESELs = { "21151112115", "21152222115", "21153332115", "21154442115", "21155552115" };
		private readonly string[] PhoneNumbers = { "111112115", "222222115", "333332115", "444442115", "555552115" };
		private readonly string[] Titles = { "Something Fishy", "Pet Sematary", "Harry Potter and the Half-Blook Prince", "Marley & Me", "Feast" };
		private readonly string[] Authors = { "Wodehouse", "King", "Rowling", "Grogan", "Masterton" };
		private readonly int[] Years = { 1957, 1983, 2005, 2006, 1988 };
		private readonly decimal[] GrossPrizes = { new decimal(12.99), new decimal(32.99), new decimal(25.99), new decimal(15.99), new decimal(30.99) };
		private readonly string[] Descriptions = { "A", "B", "C", "D", "E" };
		private readonly DateTime[] DateTimes = { new DateTime(2015, 1, 2, 14, 21, 15), new DateTime(2016, 2, 3, 15, 22, 16), new DateTime(2017, 3, 4, 16, 23, 17), new DateTime(2018, 4, 5, 17, 24, 18), new DateTime(2019, 5, 6, 18, 25, 19) };
		Random Random = new Random();

		public void Fill(DataContext dataContext)
		{
			for (int i = 0; i < 5; i++)
			{
				dataContext.Clients.Add(GenerateClient());
				dataContext.Books.Add(i + 1, GenerateBook());
				dataContext.BooksDetails.Add(GenerateBookDetails(i, dataContext));
				dataContext.Purchases.Add(GeneratePurchase(i, dataContext));
			}

		}

		private Client GenerateClient()
		{
			return new Client(FirstNames[Random.Next(FirstNames.Length)], LastNames[Random.Next(LastNames.Length)], PESELs[Random.Next(PESELs.Length)], PhoneNumbers[Random.Next(PhoneNumbers.Length)]);
		}

		private Book GenerateBook()
		{
			return new Book(Titles[Random.Next(Titles.Length)], Authors[Random.Next(Authors.Length)], Years[Random.Next(Years.Length)]);
		}

		private BookDetails GenerateBookDetails(int i, DataContext dataContext)
		{
			return new BookDetails(dataContext.Books[i], GrossPrizes[Random.Next(GrossPrizes.Length)], new decimal(0.05), Random.Next(1, 100), Descriptions[Random.Next(Descriptions.Length)]);
		}

		private Purchase GeneratePurchase(int i, DataContext dataContex)
		{
			return new Purchase(dataContex.Clients[i], DateTimes[Random.Next(DateTimes.Length)], dataContex.BooksDetails[i]);
		}
	}
}
