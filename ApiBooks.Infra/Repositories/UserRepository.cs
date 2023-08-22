using ApiBooks.Domain.Entities;
using ApiBooks.Domain.Repositories;
using ApiBooks.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BooksDbContext _context;

        public UserRepository(BooksDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
    }
}
