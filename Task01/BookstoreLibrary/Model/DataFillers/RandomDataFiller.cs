using System;

namespace BookstoreLibrary.Model
{
	public class RandomDataFiller : IDataFiller
	{
		private readonly string[] FirstNames = { "Ellie", "Luis", "Rachel", "Jud", "Gage" };
		private readonly string[] LastNames = { "Doe", "Snow", "Sanchez", "Smith", "Butler" };
		private readonly string[] PESELs = { "21151112115", "21152222115", "21153332115", "21154442115", "21155552115" };
		private readonly string[] PhoneNumbers = { "111112115", "222222115", "333332115", "444442115", "555552115" };
		private readonly string[] PublishersNumbers = { "111111111", "222222222", "333333333", "444444444", "555555555" };
		private readonly string[] Titles = { "Something Fishy", "Pet Sematary", "Harry Potter and the Half-Blook Prince", "Marley & Me", "Feast" };
		private readonly string[] Authors = { "Wodehouse", "King", "Rowling", "Grogan", "Masterton" };
		private readonly string[] Publishers = { "Publisher1", "Publisher2", "Publisher3", "Publisher4", "Publisher5"};
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
				dataContext.Publishers.Add(GeneratePublisher());
				dataContext.Books.Add(i, GenerateBook());
				dataContext.BooksDetails.Add(GenerateBookDetails(i, dataContext));
				dataContext.Purchases.Add(GenerateBuyBooks(i, dataContext));
				dataContext.Purchases.Add(GenerateSellBooks(i, dataContext));
			}

		}

		private Client GenerateClient()
		{
			return new Client(FirstNames[Random.Next(FirstNames.Length)], LastNames[Random.Next(LastNames.Length)], PESELs[Random.Next(PESELs.Length)], PhoneNumbers[Random.Next(PhoneNumbers.Length)]);
		}

		private Publisher GeneratePublisher()
		{
			return new Publisher(Publishers[Random.Next(Publishers.Length)], PublishersNumbers[Random.Next(PublishersNumbers.Length)]);
		}

		private Book GenerateBook()
		{
			return new Book(Titles[Random.Next(Titles.Length)], Authors[Random.Next(Authors.Length)], Years[Random.Next(Years.Length)]);
		}

		private BookDetails GenerateBookDetails(int i, DataContext dataContext)
		{
			return new BookDetails(dataContext.Books[i], GrossPrizes[Random.Next(GrossPrizes.Length)], new decimal(0.05), Random.Next(1, 100), Descriptions[Random.Next(Descriptions.Length)]);
		}

		private Purchase GenerateBuyBooks(int i, DataContext dataContex)
		{
			return new BuyBook(dataContex.Publishers[i], dataContex.BooksDetails[i], DateTimes[Random.Next(DateTimes.Length)], Random.Next(50, 100));
		}

		private Purchase GenerateSellBooks(int i, DataContext dataContext)
		{
			return new SellBook(dataContext.Clients[i], dataContext.BooksDetails[i], DateTimes[Random.Next(DateTimes.Length)], Random.Next(1, 20));
		}
	}
}
