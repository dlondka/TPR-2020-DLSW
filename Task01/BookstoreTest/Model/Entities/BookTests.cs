using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookstoreLibrary.Model.Entities.Tests
{
    [TestClass()]
    public class BookTests
    {
        Book book = new Book("Harry Potter", "J.K. Rowling", 1997);

        [TestMethod()]
        public void BookTest()
        {
            Assert.AreEqual(book.Name, "Harry Potter");
            Assert.AreEqual(book.Author, "J.K. Rowling");
            Assert.AreEqual(book.Year, 1997);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual(book.ToString(), "Book: \"Harry Potter\" by J.K. Rowling (1997)");
        }

        Book book2 = new Book("Krzyżacy", "Henryk Sienkiewicz", 1900);

        [TestMethod()]
        public void EqualsTest()
        {
            Assert.IsTrue(book.Equals(book));
            Assert.IsFalse(book.Equals(book2));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Assert.AreEqual(book.GetHashCode(), book.GetHashCode());
            Assert.AreNotEqual(book.GetHashCode(), book2.GetHashCode());
        }
    }
}