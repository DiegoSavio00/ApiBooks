using ApiBooks.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Domain.Entities
{
    public class BookImage
    {
        public BookImage(int bookId, string? imageUri, string imageBase)
        {
            Validation(bookId);
            ImageUri = imageUri;
            ImageBase = imageBase;
        }

        public int Id { get; private set; }
        public int BookId { get; private set; }
        public string? ImageUri { get; private set; }
        public string? ImageBase { get; private set; }
        public Book Book { get; set; }

        private void Validation(int bookId)
        {
            DomainValidationException.When(bookId == 0, "IdBook is required");
            BookId = bookId;
        }

    }
}
