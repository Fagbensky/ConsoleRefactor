using Ibridge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibridge.Application.Interfaces
{
    public interface IUserService
    {
        void AddUser(string name, string email);
        void RemoveUser(string email);
        List<User> GetAllUsers();
    }
}
