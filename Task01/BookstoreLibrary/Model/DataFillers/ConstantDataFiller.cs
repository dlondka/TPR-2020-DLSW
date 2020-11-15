using System;

namespace BookstoreLibrary
{
	public class ConstantDataFiller : IDataFiller
	{
		public void Fill(DataContext dataContext)
		{
			dataContext.Clients.Add(new Client("Ellie", "Doe", "21151112115", "111112115"));
			dataContext.Clients.Add(new Client("Luis", "Snow", "21152222115", "222222115"));
			dataContext.Clients.Add(new Client("Rachel", "Sanchez", "21153332115", "333332115"));
			dataContext.Clients.Add(new Client("Jud", "Smith", "21154442115", "444442115"));
			dataContext.Clients.Add(new Client("Gage", "Butler", "21155552115", "555552115"));

			dataContext.Books.Add(0, new Book("Something Fishy", "Wodehouse", 1957));
			dataContext.Books.Add(1, new Book("Pet Sematary", "King", 1983));
			dataContext.Books.Add(2, new Book("Harry Potter and the Half-Blook Prince", "Rowling", 2005));
			dataContext.Books.Add(3, new Book("Marley & Me", "Grogan", 2005));
			dataContext.Books.Add(4, new Book("Feast", "Masterton", 1988));

			dataContext.BooksDetails.Add(new BookDetails(dataContext.Books[0], new decimal(12.99), new decimal(0.05), 12, "Something Fishy is a novel by P. G. Wodehouse, first published in the United Kingdom on 18 January 1957 by Herbert Jenkins, London and in the United States on 28 January 1957 by Simon & Schuster, Inc., New York, under the title The Butler Did It."));
			dataContext.BooksDetails.Add(new BookDetails(dataContext.Books[1], new decimal(32.99), new decimal(0.05), 18, "Pet Sematary is a 1983 horror novel by American writer Stephen King. The novel was nominated for a World Fantasy Award for Best Novel in 1986, and adapted into two films: one in 1989 and another in 2019. In November 2013, PS Publishing released Pet Sematary in a limited 30th-anniversary edition."));
			dataContext.BooksDetails.Add(new BookDetails(dataContext.Books[2], new decimal(25.99), new decimal(0.05), 54, "Harry Potter and the Half-Blood Prince is a fantasy novel written by British author J.K. Rowling and the sixth and penultimate novel in the Harry Potter series."));
			dataContext.BooksDetails.Add(new BookDetails(dataContext.Books[3], new decimal(15.99), new decimal(0.05), 35, "Marley & Me: Life and Love with the World's Worst Dog is an autobiographical book by journalist John Grogan, published in 2005, about the 13 years he and his family spent with their yellow Labrador Retriever, Marley."));
			dataContext.BooksDetails.Add(new BookDetails(dataContext.Books[4], new decimal(30.99), new decimal(0.05), 23, "The little town of Allen's Corner in rural Connecticut hid a secret. A terrible, unimaginable secret. A secret that only the children knew. It fed on their youth, ate away at their innocence, and consumed their very souls with a twisted hunger that could never be revealed - nor ever satisfied."));

			dataContext.Purchases.Add(new Purchase(dataContext.Clients[0], new DateTime(2015, 1, 2, 14, 21, 15), dataContext.BooksDetails[0]));
			dataContext.Purchases.Add(new Purchase(dataContext.Clients[1], new DateTime(2016, 2, 3, 15, 22, 16), dataContext.BooksDetails[1]));
			dataContext.Purchases.Add(new Purchase(dataContext.Clients[2], new DateTime(2017, 3, 4, 16, 23, 17), dataContext.BooksDetails[2]));
			dataContext.Purchases.Add(new Purchase(dataContext.Clients[3], new DateTime(2018, 4, 5, 17, 24, 18), dataContext.BooksDetails[3]));
			dataContext.Purchases.Add(new Purchase(dataContext.Clients[4], new DateTime(2019, 5, 6, 18, 25, 19), dataContext.BooksDetails[4]));
		}
	}
}
