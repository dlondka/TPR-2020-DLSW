using System;
using System.IO;

namespace BookstoreLibrary
{
	public class FileDataFiller : IDataFiller
	{
		public void Fill(DataContext dataContext)
		{
			ReadData(dataContext);
		}


		public void ReadData(DataContext dataContext)
		{
			int key = 1;
			int bookDetailsCounter = 1;
			int purchaseCounter = 1;
			Console.WriteLine("Project dir: " + "$(ProjectDir)");
			try
			{
				using (StreamReader sr = new StreamReader("..\\..\\..\\BookstoreLibrary\\Model\\DataFillers\\SampleData.txt"))
				{
					string singleLine;
					while ((singleLine = sr.ReadLine()) != null)
					{
						string[] splitLine = singleLine.Split('+');
						if (splitLine[0] == "Client")
						{
							dataContext.Clients.Add(new Client(splitLine[1], splitLine[2], splitLine[3], splitLine[4]));
						}
						else if (splitLine[0] == "Book")
						{
							dataContext.Books.Add(key, new Book(splitLine[1], splitLine[2], Int32.Parse(splitLine[3])));
							key++;
						}
						else if (splitLine[0] == "BookDetails")
						{
							dataContext.BooksDetails.Add(new BookDetails(dataContext.Books[bookDetailsCounter], Decimal.Parse(splitLine[1]), Decimal.Parse(splitLine[2]), Int32.Parse(splitLine[3]), splitLine[4]));
							bookDetailsCounter++;
						}
						else if (splitLine[0] == "Purchase")
						{
							dataContext.Purchases.Add(new Purchase(dataContext.Clients[purchaseCounter], DateTime.Parse(splitLine[1]), dataContext.BooksDetails[purchaseCounter]));
							purchaseCounter++;
						}
					}
				}
			}
			catch (FormatException e)
			{
				Console.WriteLine("Error during parsing the year: " + e.Message);
			}
			catch (Exception e)
			{
				Console.WriteLine("The file could not be read: " + e.Message);
			}
		}
	}
}
