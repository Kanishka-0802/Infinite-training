using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Features
{
    public class EmployeeRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public bool IsVeteran { get; set; }
    }

    public interface IEmployeeDataReader
    {
        EmployeeRecord GetEmployeeRecord(int employeeId);
    }

    public class MockEmployeeDataReader : IEmployeeDataReader
    {
        public EmployeeRecord GetEmployeeRecord(int employeeId)
        {
            if (employeeId == 202501)
                return new EmployeeRecord { Id = 202501, Name = "Kanishka", Role = "Developer", IsVeteran = false };
            else if (employeeId == 202502)
                return new EmployeeRecord { Id = 202502, Name = "Preethi", Role = "Consultant", IsVeteran = true };
            else if (employeeId == 202503)
                return new EmployeeRecord { Id = 202503, Name = "Sastika", Role = "Manager", IsVeteran = true };
            else if (employeeId == 202504)
                return new EmployeeRecord { Id = 202504, Name = "Mahitha", Role = "Tester", IsVeteran = false };
            else if (employeeId == 202505)
                return new EmployeeRecord { Id = 202505, Name = "Yuvarani", Role = "Manager", IsVeteran = false };
            else if (employeeId == 202506)
                return new EmployeeRecord { Id = 202506, Name = "Abirami", Role = "Developer", IsVeteran = true };
            else if (employeeId == 202507)
                return new EmployeeRecord { Id = 202507, Name = "Janani", Role = "Intern", IsVeteran = false };
            else
                return new EmployeeRecord { Id = employeeId, Name = "Unknown", Role = "Other", IsVeteran = false };
        }
    }

    public class PayrollProcessor
    {
        private readonly IEmployeeDataReader data;

        private static readonly Dictionary<int, decimal> BaseSalary = new Dictionary<int, decimal>
     {
        { 202501, 65000m },
        { 202502, 120000m },
        { 202503, 30000m }
     };


        public PayrollProcessor(IEmployeeDataReader dataReader)
        {
            data = dataReader;
        }

        public decimal CalculateTotalCompensation(int employeeId)
        {
            var employee = data.GetEmployeeRecord(employeeId);

            decimal baseSalary = 0m;
            if (BaseSalary.ContainsKey(employeeId))
            {
                baseSalary = BaseSalary[employeeId];
            }

            decimal bonus = 0m;
            if (employee.Role == "Manager" && employee.IsVeteran)
            {
                bonus = 10000m;
            }
            else if (employee.Role == "Manager" && !employee.IsVeteran)
            {
                bonus = 5000m;
            }
            else if (employee.Role == "Developer")
            {
                bonus = 2000m;
            }
            else if (employee.Role == "Intern")
            {
                bonus = 1500m;
            }
            else if (employee.Role == "Consultant")
            {
                bonus = 3000m;
            }
            else
            {
                bonus = 0m;
            }

            return baseSalary + bonus;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            IEmployeeDataReader reader = new MockEmployeeDataReader();
            var payroll = new PayrollProcessor(reader);

            int[] employeeIds = { 202501, 202502, 202503, 202504, 202505, 202506, 202507 };

            foreach (var id in employeeIds)
            {
                var employee = reader.GetEmployeeRecord(id);
                decimal totalAmount = payroll.CalculateTotalCompensation(id);

                WriteLine($"Employee: {employee.Name} (ID: {employee.Id}, Role: {employee.Role}, Veteran: {employee.IsVeteran})");
                WriteLine($"Total Amount  : {totalAmount:C}");
                WriteLine(new string('-', 50));
            }

            WriteLine("Application is Processed....");
            ReadKey();
        }
    }
}

