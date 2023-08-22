using ApiBooks.Domain.Entities;
using ApiBooks.Domain.Filters;
using ApiBooks.Domain.Paged;
using ApiBooks.Domain.Repositories;
using ApiBooks.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksDbContext _context;

        public BookRepository(BooksDbContext context)
        {
            _context = context;
        }

        public async Task<Book> CreateAsync(Book book)
        {
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteAsync(Book book)
        {
            _context.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Book book)
        {
            _context.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Book>> GetAllAsync()
        {
            return await _context.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.Include(c => c.Category).SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<PagedBaseResponse<Book>> GetPagedAsync(BookFilterDb request)
        {
            var book = _context.Books.AsQueryable();
            if (!string.IsNullOrEmpty(request.Title))
                book = book.Where(x => x.Title.Contains(request.Title));
            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseResponse<Book>, Book>(book, request);
        }
    }
}
