using ApiBooks.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Domain.Entities
{
    public sealed class Category
    {
        public Category(int id, string name)
        {
            DomainValidationException.When(id < 0, "Id is required");
            Id = id;
            Validation(name);
            Products = new List<Book>();
        }

        public Category(string name)
        {
            Validation(name);
            Products = new List<Book>();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<Book> Products { get; set; }

        private void Validation(string name)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Name is required");
            Name = name;
        }

    }
}
