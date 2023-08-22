using ApiBooks.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Domain.Entities
{
    public class User
    {
        public User(string email, string password)
        {
            Validation(email, password);
        }

        public User(int id, string email, string password)
        {
            DomainValidationException.When(id <= 0, "Id is required");
            Id = id;
            Validation(email, password);
        }

        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        private void Validation(string email, string password)
        {
            DomainValidationException.When(string.IsNullOrEmpty(email), "Email is required!");
            DomainValidationException.When(string.IsNullOrEmpty(password), "Password is required");
            Email = email;
            Password = password;
        }

    }
}
