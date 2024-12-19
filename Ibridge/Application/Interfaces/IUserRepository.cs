using Ibridge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibridge.Application.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void RemoveUser(string email);
        List<User> GetAllUsers();
    }
}
