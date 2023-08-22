using ApiBooks.Application.DTOs;
using ApiBooks.Application.DTOs.Book;
using ApiBooks.Application.DTOs.Book.Validator;
using ApiBooks.Application.Services.Interfaces;
using ApiBooks.Domain.Entities;
using ApiBooks.Domain.Filters;
using ApiBooks.Domain.Repositories;
using AutoMapper;

namespace ApiBooks.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepo, IMapper mapper)
        {
            _bookRepo = bookRepo ?? throw new ArgumentNullException(nameof(bookRepo));
            _mapper = mapper;
        }

        public async Task<ResultService<BookDTO>> CreateAsync(BookDTO bookDto)
        {
            if (bookDto == null)
                return ResultService.Fail<BookDTO>("Object is required");
            var result = new BookDTOValidator().Validate(bookDto);
            if (!result.IsValid)
                return ResultService.RequestError<BookDTO>("Problems with validate", result);
            var book = _mapper.Map<Book>(bookDto);
            var data = await _bookRepo.CreateAsync(book);
            return ResultService.Ok(_mapper.Map<BookDTO>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book is null)
                return ResultService.Fail("Book Not Found!!");
            return ResultService.Ok($"Book:{id} deleted!");
        }

        public async Task<ResultService<ICollection<BookDTO>>> GetAllAsync()
        {
            var books = await _bookRepo.GetAllAsync();
            return ResultService.Ok(_mapper.Map<ICollection<BookDTO>>(books));
        }

        public async Task<ResultService<BookDTO>> GetByIdAsync(int id)
        {
            var books = await _bookRepo.GetByIdAsync(id);
            if (books == null)
                return ResultService.Fail<BookDTO>("Book not Found!");
            return ResultService.Ok(_mapper.Map<BookDTO>(books));
        }

        public async Task<ResultService<PagedBaseResponseDTO<BookDTO>>> GetPagedAsync(BookFilterDb bookFilterDb)
        {
            var bookPaged = await _bookRepo.GetPagedAsync(bookFilterDb);
            var result = new PagedBaseResponseDTO<BookDTO>(bookPaged.TotalRegisters,
                _mapper.Map<List<BookDTO>>(bookPaged.Data));
            return ResultService.Ok(result);
        }

        public async Task<ResultService> UpdateAsync(BookDTO bookDto)
        {
            if (bookDto is null)
                return ResultService.Fail("Object is required");
            var validation = new BookDTOValidator().Validate(bookDto);
            if (!validation.IsValid)
                return ResultService.RequestError("Problem with validations", validation);
            var book = await _bookRepo.GetByIdAsync(bookDto.Id);
            if (book == null)
                return ResultService.Fail("Book not foun!");
            book = _mapper.Map(bookDto, book);
            await _bookRepo.EditAsync(book);
            return ResultService.Ok("Book Edited!");
        }
    }
}
