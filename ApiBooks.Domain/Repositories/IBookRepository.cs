using ApiBooks.Domain.Entities;
using ApiBooks.Domain.Filters;
using ApiBooks.Domain.Paged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(int id);
        Task<ICollection<Book>> GetAllAsync();
        Task<Book> CreateAsync(Book book);
        Task EditAsync(Book book);
        Task DeleteAsync(Book book);
        Task<PagedBaseResponse<Book>> GetPagedAsync(BookFilterDb request);
    }
}
