using System.Collections.Generic;

namespace BookstoreLibrary.Model.Entities
{
	public class Book
	{
		public string Name;
		public string Author { get; set; }
		public int Year { get; set; }

		public Book(string name, string author, int year)
		{
			this.Name = name;
			this.Author = author;
			this.Year = year;
		}

		public override string ToString()
		{
			return $"Book: name = {Name}, author = {Author}, year = {Year}";
		}

        public override bool Equals(object obj)
        {
            return obj is Book book &&
                   Name == book.Name &&
                   Author == book.Author &&
                   Year == book.Year;
        }

        public override int GetHashCode()
        {
            int hashCode = 151300744;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
            hashCode = hashCode * -1521134295 + Year.GetHashCode();
            return hashCode;
        }
    }
}
