﻿using System;
using System.IO;
using BookstoreLibrary.Model;

namespace BookstoreLibrary.Filler
{
	public class FileDataFiller : IDataFiller
	{
		public DataContext Fill(DataContext dataContext)
		{
			ReadData(dataContext);
			return dataContext;
		}


		private void ReadData(DataContext dataContext)
		{
			int key = 0;
			int bookDetailsCounter = 0;
			int purchaseCounter = 0;
			try
			{
				using (StreamReader sr = new StreamReader(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\BookstoreModelTest\\Model\\DataFillers\\DataFillers\\SampleData.txt"))
				{
					string singleLine;
					while ((singleLine = sr.ReadLine()) != null)
					{
						string[] splitLine = singleLine.Split('+');
						if (splitLine[0] == "Client")
						{
							dataContext.Clients.Add(new Client(splitLine[1], splitLine[2], splitLine[3], splitLine[4]));
						}
						else if (splitLine[0] == "Publisher")
						{
							dataContext.Publishers.Add(new Publisher(splitLine[1], splitLine[2]));
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
						else if (splitLine[0] == "BuyBook")
						{
							dataContext.Purchases.Add(new BuyBook(dataContext.Publishers[purchaseCounter % 5], dataContext.BooksDetails[purchaseCounter % 5], DateTime.Parse(splitLine[1]), Int32.Parse(splitLine[2])));
							purchaseCounter++;
						}
						else if (splitLine[0] == "SellBook")
						{
							dataContext.Purchases.Add(new SellBook(dataContext.Clients[purchaseCounter % 5], dataContext.BooksDetails[purchaseCounter % 5], DateTime.Parse(splitLine[1]), Int32.Parse(splitLine[2])));
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
