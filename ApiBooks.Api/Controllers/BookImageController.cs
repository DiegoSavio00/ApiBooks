using ApiBooks.Application.DTOs.BookImage;
using ApiBooks.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBooks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookImageController : ControllerBase
    {
        private readonly IBookImageService _bookImageService;

        public BookImageController(IBookImageService bookImageService)
        {
            _bookImageService = bookImageService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateImageBase64Async(BookImageDTO bookImageDTO)
        {
            var result = await _bookImageService.CreateImageBase64Async(bookImageDTO);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

    }
}
