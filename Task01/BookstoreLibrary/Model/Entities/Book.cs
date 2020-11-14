using System;
using System.Collections.Generic;
using System.Text;

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
            if ( obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                Book b = (Book)obj;
                return (this.Name.Equals(b.Name) && this.Author.Equals(b.Author) && this.Year.Equals(b.Year));
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
