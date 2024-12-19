using Ibridge.Application.Interfaces;
using Ibridge.Application.Services;
using Ibridge.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibridge.test.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockRepo = new Mock<IUserRepository>();
            _userService = new UserService(_mockRepo.Object);
        }

        [Fact]
        public void AddUser_ShouldCallRepositoryAdd()
        {
            var userName = "John Doe";
            var userEmail = "john.doe@example.com";

            _userService.AddUser(userName, userEmail);
            _mockRepo.Verify(repo => repo.AddUser(It.Is<User>(
                u => u.Name == userName && u.Email == userEmail)), Times.Once);
        }

        [Fact]
        public void RemoveUser_ShouldCallRepositoryRemove()
        {
            var email = "john.doe@example.com";

            _userService.RemoveUser(email);
            _mockRepo.Verify(repo => repo.RemoveUser(email), Times.Once);
        }

        [Fact]
        public void GetAllUsers_ShouldReturnUsers()
        {
            var users = new List<User>
            {
                new User("John Doe", "john.doe@example.com"),
                new User("Jane Smith", "jane.smith@example.com")
            };

            _mockRepo.Setup(repo => repo.GetAllUsers()).Returns(users);

            var result = _userService.GetAllUsers();

            Assert.Equal(2, result.Count);
            Assert.Contains(result, u => u.Email == "john.doe@example.com");
        }
    }
}
