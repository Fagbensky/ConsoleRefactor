using Ibridge.Application.Interfaces;
using Ibridge.Application.Services;
using Ibridge.Infrastructure.Repository;

namespace Ibridge
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Setup infrastructure and services
            IUserRepository userRepository = new InMemoryUserRepository();
            IUserService userService = new UserService(userRepository);
            IReportService reportService = new ReportService(userRepository);

            // Interactive console menu
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n===== User Management System =====");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Remove User");
                Console.WriteLine("3. Generate Report");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddUser(userService);
                        break;

                    case "2":
                        RemoveUser(userService);
                        break;

                    case "3":
                        GenerateReport(reportService);
                        break;

                    case "4":
                        exit = true;
                        Console.WriteLine("Exiting... Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void AddUser(IUserService userService)
        {
            Console.Write("Enter user name: ");
            var name = Console.ReadLine();

            Console.Write("Enter user email: ");
            var email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Name and Email cannot be empty.");
                return;
            }

            userService.AddUser(name, email);
            Console.WriteLine($"User '{name}' added successfully!");
        }

        private static void RemoveUser(IUserService userService)
        {
            Console.Write("Enter user email to remove: ");
            var email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email cannot be empty.");
                return;
            }

            userService.RemoveUser(email);
            Console.WriteLine($"Attempted to remove user with email: {email}");
        }

        private static void GenerateReport(IReportService reportService)
        {
            Console.WriteLine("Generating user report...");
            var report = reportService.GenerateReport();
            Console.WriteLine(report);
        }
    }
}
