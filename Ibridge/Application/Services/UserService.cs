using Ibridge.Application.Interfaces;
using Ibridge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibridge.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public void AddUser(string name, string email)
        {
            var user = new User(name, email);
            _userRepository.AddUser(user);
        }

        public void RemoveUser(string email)
        {
            _userRepository.RemoveUser(email);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}
