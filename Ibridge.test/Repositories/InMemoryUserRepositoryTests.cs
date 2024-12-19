using Ibridge.Domain.Models;
using Ibridge.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibridge.test.Repositories
{
    public class InMemoryUserRepositoryTests
    {
        private readonly InMemoryUserRepository _repository;

        public InMemoryUserRepositoryTests()
        {
            _repository = new InMemoryUserRepository();
        }

        [Fact]
        public void AddUser_ShouldAddUserToRepository()
        {
            var user = new User("John Doe", "john.doe@example.com");

            _repository.AddUser(user);

            var users = _repository.GetAllUsers();
            Assert.Single(users);
            Assert.Equal("John Doe", users[0].Name);
        }

        [Fact]
        public void RemoveUser_ShouldRemoveUserFromRepository()
        {
            var user = new User("John Doe", "john.doe@example.com");
            _repository.AddUser(user);

            _repository.RemoveUser("john.doe@example.com");

            var users = _repository.GetAllUsers();

            Assert.Empty(users);
        }

        [Fact]
        public void GetAllUsers_ShouldReturnAllUsers()
        {
            _repository.AddUser(new User("John Doe", "john.doe@example.com"));
            _repository.AddUser(new User("Jane Smith", "jane.smith@example.com"));

            var users = _repository.GetAllUsers();

            Assert.Equal(2, users.Count);
        }
    }
}
