using ApiBooks.Application.DTOs.Book;
using ApiBooks.Application.Services;
using ApiBooks.Application.Services.Interfaces;
using ApiBooks.Domain.Filters;
using ApiBooks.Domain.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBooks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] BookDTO bookDTO)
        {
            try
            {
                var result = await _bookService.CreateAsync(bookDTO);
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
        public async Task<ActionResult> GetAsync()
        {
            try
            {
                var result = await _bookService.GetAllAsync();
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
                var result = await _bookService.GetByIdAsync(id);
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

        [HttpPut]
        public async Task<ActionResult> EditAsync([FromBody] BookDTO bookDTO)
        {
            try
            {
                var result = await _bookService.UpdateAsync(bookDTO);
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
                var result = await _bookService.DeleteAsync(id);
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
        [Route("paged")]
        public async Task<ActionResult> GetPagedAsync([FromQuery] BookFilterDb bookFilterDb)
        {
            try
            {
                var result = await _bookService.GetPagedAsync(bookFilterDb);
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
    }
}
