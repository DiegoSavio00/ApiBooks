using ApiBooks.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResultService<dynamic>> GeneratorTokenAsync(UserDTO userDTO);
    }
}
