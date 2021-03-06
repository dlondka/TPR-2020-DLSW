﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreLibrary.Model;

namespace BookstoreLibrary.ModelTests
{
    [TestClass()]
    public class BookDetailsTests
    {
        static Book book = new Book("Harry Potter", "J.K. Rowling", 1997);
        BookDetails bookDetails = new BookDetails(book, new decimal(19.99), new decimal(0.05), 12, "Book about adventures of young Wizzard Harry");
        [TestMethod()]
        public void BookDetailsTest()
        {
            Assert.IsTrue(bookDetails.Book.Equals(book));
            Assert.IsTrue(bookDetails.GrossPrice.Equals(new decimal(19.99)));
            Assert.IsTrue(bookDetails.Tax.Equals(new decimal(0.05)));
            Assert.IsTrue(bookDetails.Count.Equals(12));
            Assert.IsTrue(bookDetails.Description.Equals("Book about adventures of young Wizzard Harry"));
        }


        BookDetails bd2 = new BookDetails(book, new decimal(20.20), new decimal(0.20), 123, "Cooking book");
        [TestMethod()]
        public void EqualsTest()
        {
            
            Assert.IsTrue(bookDetails.Equals(bookDetails));
            Assert.IsFalse(bookDetails.Equals(bd2));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Assert.AreEqual(bookDetails.GetHashCode(), bookDetails.GetHashCode());
            Assert.AreNotEqual(bookDetails.GetHashCode(), bd2.GetHashCode());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual(bookDetails.ToString(), $"Book details: {book}, price: 19,99, tax: 5,00%, count: 12, description: \"Book about adventures of young Wizzard Harry\"\n");
        }
    }
}