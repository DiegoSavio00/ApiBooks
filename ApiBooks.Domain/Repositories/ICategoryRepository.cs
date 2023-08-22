using ApiBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(int id);
        Task<ICollection<Category>> GetCategoriesAsync();
        Task<Category> CreateAsync(Category category);
        Task EditAsync(Category category);
        Task DeleteAsync(Category category);
    }
}
