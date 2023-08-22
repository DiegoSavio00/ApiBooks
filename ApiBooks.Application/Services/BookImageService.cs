using ApiBooks.Application.DTOs.Book.Validator;
using ApiBooks.Application.DTOs.BookImage;
using ApiBooks.Application.DTOs.BookImage.Validator;
using ApiBooks.Application.Services.Interfaces;
using ApiBooks.Domain.Entities;
using ApiBooks.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Application.Services
{
    public class BookImageService : IBookImageService
    {
        private readonly IBookImageRepository _bookImageRepo;
        private readonly IBookRepository _bookRepo;

        public BookImageService(IBookImageRepository bookImageRepo, IBookRepository bookRepo)
        {
            _bookImageRepo = bookImageRepo;
            _bookRepo = bookRepo;
        }

        public async Task<ResultService> CreateImageBase64Async(BookImageDTO bookImageDTO)
        {
            if (bookImageDTO == null)
                return ResultService.Fail("Object is required!");
            var validator = new BookImageDTOValidator().Validate(bookImageDTO);
            if (!validator.IsValid)
                return ResultService.RequestError("Problems with Validation", validator);
            var book = await _bookRepo.GetByIdAsync(bookImageDTO.BookId);
            if (book is null)
                return ResultService.Fail("Book Id not Found!");
            var bookImage = new BookImage(book.Id, null, bookImageDTO.Image);
            await _bookImageRepo.CreateAsync(bookImage);
            return ResultService.Ok("Image Saved!");
        }
    }
}
