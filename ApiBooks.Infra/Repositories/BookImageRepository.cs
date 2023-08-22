using ApiBooks.Domain.Entities;
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
    public class BookImageRepository : IBookImageRepository
    {
        private readonly BooksDbContext _context;

        public BookImageRepository(BooksDbContext context)
        {
            _context = context;
        }

        public async Task<BookImage> CreateAsync(BookImage bookImage)
        {
            await _context.AddAsync(bookImage);
            await _context.SaveChangesAsync();
            return bookImage;
        }

        public async Task EditAsync(BookImage bookImage)
        {
            _context.Update(bookImage);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<BookImage>> GetByBookIdAsync(int bookId)
        {
            return await _context.BookImages.AsNoTracking().Where(x => x.BookId == bookId).ToListAsync();
        }

        public async Task<BookImage?> GetByIdAsync(int id)
        {
            return await _context.BookImages.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
