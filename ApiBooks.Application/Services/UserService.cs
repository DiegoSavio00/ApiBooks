using ApiBooks.Application.DTOs.User;
using ApiBooks.Application.DTOs.User.Validator;
using ApiBooks.Application.Services.Interfaces;
using ApiBooks.Domain.Authentication;
using ApiBooks.Domain.Repositories;

namespace ApiBooks.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ResultService<dynamic>> GeneratorTokenAsync(UserDTO userDTO)
        {
            if (userDTO == null)
                return ResultService.Fail<dynamic>("Object is required");
            var validator = new UserDTOValidator().Validate(userDTO);
            if (!validator.IsValid)
                return ResultService.RequestError<dynamic>("Problems with validation", validator);
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(userDTO.Email, userDTO.Password);
            if (user == null)
                return ResultService.Fail<dynamic>("User and password not found!");
            return ResultService.Ok(_tokenGenerator.Generator(user));
        }
    }
}
