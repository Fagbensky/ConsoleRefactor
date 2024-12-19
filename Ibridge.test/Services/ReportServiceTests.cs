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
    public class ReportServiceTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly ReportService _reportService;

        public ReportServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _reportService = new ReportService(_mockUserRepository.Object);
        }

        [Fact]
        public void GenerateReport_ShouldReturnFormattedReport()
        {
            var users = new List<User>
            {
                new User("John Doe", "john.doe@example.com"),
                new User("Jane Smith", "jane.smith@example.com")
            };

            _mockUserRepository.Setup(service => service.GetAllUsers()).Returns(users);

            var report = _reportService.GenerateReport();

            Assert.Contains("John Doe", report);
            Assert.Contains("Jane Smith", report);
        }

        [Fact]
        public void GenerateReport_WhenNoUsers_ShouldReturnNoUsersMessage()
        {
            _mockUserRepository.Setup(service => service.GetAllUsers()).Returns(new List<User>());

            var report = _reportService.GenerateReport();

            Assert.Equal("No users available.", report);
        }
    }
}
