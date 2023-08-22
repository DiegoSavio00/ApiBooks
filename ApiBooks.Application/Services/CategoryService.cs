using ApiBooks.Application.DTOs.Category;
using ApiBooks.Application.DTOs.Category.Validator;
using ApiBooks.Application.Services.Interfaces;
using ApiBooks.Domain.Entities;
using ApiBooks.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<ResultService<CategoryDTO>> CreateAsync(CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
                return ResultService.Fail<CategoryDTO>("Object is required!");
            var result = new CategoryDTOValidator().Validate(categoryDTO);
            if (!result.IsValid)
                return ResultService.RequestError<CategoryDTO>("Valid Problems", result);
            var category = _mapper.Map<Category>(categoryDTO);
            var data = await _categoryRepo.CreateAsync(category);
            return ResultService.Ok(_mapper.Map<CategoryDTO>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category is null)
                return ResultService.Fail("Category Not Found!");
            await _categoryRepo.DeleteAsync(category);
            return ResultService.Ok($"Category id:{id} has been deleted!");
        }

        public async Task<ResultService<ICollection<CategoryDTO>>> GetAllAsync()
        {
            var category = await _categoryRepo.GetCategoriesAsync();
            return ResultService.Ok(_mapper.Map<ICollection<CategoryDTO>>(category));
        }

        public async Task<ResultService<CategoryDTO>> GetByIdAsync(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category is null)
                return ResultService.Fail<CategoryDTO>("Category Not Found!!");
            return ResultService.Ok(_mapper.Map<CategoryDTO>(category));
        }

        public async Task<ResultService> UpdateAsync(CategoryDTO categoryDTO)
        {
            if (categoryDTO is null)
                return ResultService.Fail("Object is required");
            var validation = new CategoryDTOValidator().Validate(categoryDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problem with valid fields", validation);
            var category = await _categoryRepo.GetByIdAsync(categoryDTO.Id);
            await _categoryRepo.EditAsync(category);
            return ResultService.Ok("Category Edited!");
        }
    }
}
