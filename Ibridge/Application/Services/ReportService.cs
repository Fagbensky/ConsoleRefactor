using Ibridge.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibridge.Application.Services
{
    public class ReportService: IReportService
    {
        private readonly IUserRepository _userRepository;

        public ReportService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string GenerateReport()
        {
            var users = _userRepository.GetAllUsers();

            if (!users.Any())
            {
                return "No users available.";
            }

            var report = "User Report:\n";
            foreach (var user in users)
            {
                report += $"- {user.Name} ({user.Email})\n";
            }
            return report;
        }
    }
}
