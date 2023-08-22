using ApiBooks.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Domain.Entities
{
    public sealed class Book
    {
        public Book(string title, string author, decimal price)
        {
            Validation(title, author, price);
            BookImages = new List<BookImage>();
        }

        public Book(int id, string title, string author, decimal price, int categoryId)
        {
            DomainValidationException.When(id < 0, "Id is required");
            Validation(title, author, price);
            Id = id;
            CategoryId = categoryId;
            BookImages = new List<BookImage>();
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<BookImage> BookImages { get; private set; }

        private void Validation(string title, string author, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(title), "Name is required");
            DomainValidationException.When(string.IsNullOrEmpty(author), "Code is required");
            DomainValidationException.When(price < 0, "Price is required");
            Title = title;
            Author = author;
            Price = price;
        }

        public int CategoryId { get; private set; }
        public Category Category { get; set; }

    }
}
