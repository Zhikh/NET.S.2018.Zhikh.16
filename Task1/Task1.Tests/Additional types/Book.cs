using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests.Additional_types
{
    public sealed class Book
    {
        private string _name;
        private string _author;
        private int _pages;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"{nameof(Name)} can't be null or empty!");
                }

                _name = value;
            }
        }

        public string Author
        {
            get
            {
                return _author;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"{nameof(Author)} can't be null or empty!");
                }

                _author = value;
            }
        }

        public int Pages
        {
            get
            {
                return _pages;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException($"{nameof(Pages)} can't be zero or less than zero!");
                }

                _pages = value;
            }
        }

        public override bool Equals(object obj)
        {
            var book = obj as Book;
            return book != null &&
                   _name == book._name &&
                   _author == book._author &&
                   _pages == book._pages &&
                   Name == book.Name &&
                   Author == book.Author &&
                   Pages == book.Pages;
        }

        public override int GetHashCode()
        {
            var hashCode = -1347137861;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_author);
            hashCode = hashCode * -1521134295 + _pages.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
            hashCode = hashCode * -1521134295 + Pages.GetHashCode();
            return hashCode;
        }
    }
}
