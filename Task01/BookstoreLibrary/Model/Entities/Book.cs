using System.Collections.Generic;

namespace BookstoreLibrary
{
	public class Book
	{
		public string Title;
		public string Author { get; set; }
		public int Year { get; set; }

		public Book(string title, string author, int year)
		{
			this.Title = title;
			this.Author = author;
			this.Year = year;
		}

		public override string ToString()
		{
			return $"Book: \"{Title}\" by {Author} ({Year})";
		}

        public override bool Equals(object obj)
        {
            return obj is Book book &&
                   Title == book.Title &&
                   Author == book.Author &&
                   Year == book.Year;
        }

        public override int GetHashCode()
        {
            int hashCode = 151300744;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
            hashCode = hashCode * -1521134295 + Year.GetHashCode();
            return hashCode;
        }
    }
}
