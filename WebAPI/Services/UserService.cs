using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using WebAPI.Data;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        public UserService(IRepository<User> userRepository)
        {
            _repository = userRepository;
        }

        public User UserValidator(RegisterRequest registerRequest)
        {
            if (UserWithEmailExists(registerRequest.Email) || UserWithUsernameExists(registerRequest.Username))
            {
                return null;// 
            }

            registerRequest.Password = Crypto.SHA256(registerRequest.Password);

            User user = new User
            {
                Email = registerRequest.Email,
                Username = registerRequest.Username,
                Password = registerRequest.Password
            };
            return user;
        }
        private bool UserWithEmailExists(string email)
        {
            return _repository.GetAll().Where(u => u.Email == email).FirstOrDefault() != null;
        }

        private bool UserWithUsernameExists(string username)
        {
            return _repository.GetAll().Where(u => u.Username == username).FirstOrDefault() != null;
        }
    }
}
