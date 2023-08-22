using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Application.DTOs.BookImage.Validator
{
    internal class BookImageDTOValidator : AbstractValidator<BookImageDTO>
    {
        public BookImageDTOValidator()
        {
            RuleFor(x => x.BookId).GreaterThanOrEqualTo(0).WithMessage("BookId cannot be less than or equal to zero");
            RuleFor(x => x.Image).NotEmpty().NotNull().WithMessage("Image is required");
        }
    }
}
