using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Application.DTOs.Book.Validator
{
    public class BookDTOValidator : AbstractValidator<BookDTO>
    {
        public BookDTOValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("Title is required!");
            RuleFor(x => x.Author).NotEmpty().NotNull().WithMessage("Author is required!");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must have greater then 0");
        }
    }
}
