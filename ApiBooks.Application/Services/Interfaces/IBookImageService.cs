using ApiBooks.Application.DTOs.BookImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Application.Services.Interfaces
{
    public interface IBookImageService
    {
        Task<ResultService> CreateImageBase64Async(BookImageDTO bookImageDTO);
    }
}
