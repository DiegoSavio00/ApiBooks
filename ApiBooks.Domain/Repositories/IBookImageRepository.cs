using ApiBooks.Domain.Entities;

namespace ApiBooks.Domain.Repositories
{
    public interface IBookImageRepository
    {
        Task<BookImage?> GetByIdAsync(int id);
        Task<BookImage> CreateAsync(BookImage bookImage);
        Task<ICollection<BookImage>> GetByBookIdAsync(int bookId);
        Task EditAsync(BookImage bookImage);
    }
}
