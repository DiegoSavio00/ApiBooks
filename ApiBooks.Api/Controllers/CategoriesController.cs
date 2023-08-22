using ApiBooks.Application.DTOs.Category;
using ApiBooks.Application.Services;
using ApiBooks.Application.Services.Interfaces;
using ApiBooks.Domain.Validations;
using Microsoft.AspNetCore.Mvc;

namespace ApiBooks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CategoryDTO categoryDTO)
        {
            var result = await _categoryService.CreateAsync(categoryDTO);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var result = await _categoryService.GetAllAsync();
                if (result.IsSuccess)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _categoryService.GetByIdAsync(id);
                if (result.IsSuccess)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return Ok(result);
            }
        }

        [HttpPut]
        public async Task<ActionResult> EditAsync([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                var result = await _categoryService.UpdateAsync(categoryDTO);
                if (result.IsSuccess)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await _categoryService.DeleteAsync(id);
                if (result.IsSuccess)
                    return BadRequest(result);
                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }
        }

    }
}
