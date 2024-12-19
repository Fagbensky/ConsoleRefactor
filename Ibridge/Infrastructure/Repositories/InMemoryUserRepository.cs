using Ibridge.Application.Interfaces;
using Ibridge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibridge.Infrastructure.Repository
{
    public class InMemoryUserRepository: IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void RemoveUser(string email)
        {
            var user = _users.FirstOrDefault(u => u.Email == email);
            if (user != null)
                _users.Remove(user);
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }
    }
}
