using ApiBooks.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ResultService<CategoryDTO>> CreateAsync(CategoryDTO categoryDTO);
        Task<ResultService<ICollection<CategoryDTO>>> GetAllAsync();
        Task<ResultService<CategoryDTO>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(CategoryDTO categoryDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}
