using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreLibrary.Model.Entities
{
	public class BookDetails
	{
        public Book Book { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal Tax { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }

        public BookDetails(Book book, decimal grossPrice, decimal tax, int count, string description)
        {
            Book = book;
            GrossPrice = grossPrice;
            Tax = tax;
            Count = count;
            Description = description;
        }

        public override bool Equals(object obj)
        {
            return obj is BookDetails stock &&
                   EqualityComparer<Book>.Default.Equals(Book, stock.Book) &&
                   GrossPrice == stock.GrossPrice &&
                   Tax == stock.Tax &&
                   Count == stock.Count &&
                   Description == stock.Description;
        }

        public override int GetHashCode()
        {
            int hashCode = -1642329463;
            hashCode = hashCode * -1521134295 + EqualityComparer<Book>.Default.GetHashCode(Book);
            hashCode = hashCode * -1521134295 + GrossPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + Tax.GetHashCode();
            hashCode = hashCode * -1521134295 + Count.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            return hashCode;
        }

        public override string ToString()
        {
            return $"BookDetails: {Book}, price = {GrossPrice}, tax = {Tax}, count = {Count} description = {Description}";
        }
    }
}
