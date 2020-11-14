using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreLibrary.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreLibrary.Model.Entities.Tests
{
    [TestClass()]
    public class BookDetailsTests
    {
        
        [TestMethod()]
        public void BookDetailsTest()
        {
            Book book = new Book("Harry Potter", "J.K. Rowling", 1997);
            BookDetails bookDetails = new BookDetails(book, new decimal(19.99), new decimal(0.05), 12, "Book about adventures of young Wizzard Harry");

        }

        [TestMethod()]
        public void EqualsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }
    }
}