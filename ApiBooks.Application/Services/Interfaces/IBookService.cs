using ApiBooks.Application.DTOs;
using ApiBooks.Application.DTOs.Book;
using ApiBooks.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Application.Services.Interfaces
{
    public interface IBookService
    {
        Task<ResultService<BookDTO>> CreateAsync(BookDTO bookDto);
        Task<ResultService<ICollection<BookDTO>>> GetAllAsync();
        Task<ResultService<BookDTO>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(BookDTO bookDto);
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService<PagedBaseResponseDTO<BookDTO>>> GetPagedAsync(BookFilterDb bookFilterDb);
    }
}
