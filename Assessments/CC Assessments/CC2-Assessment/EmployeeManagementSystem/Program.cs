using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeeManagementSystem.Employee;

namespace EmployeeManagementSystem
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public int Experience { get; set; }

        public delegate void PrintEmployeeDelegate(Employee emp);


        public delegate bool FilterEmployeeDelegate(Employee emp);

        
    }
        internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee{EmpId=801,EmployeeName="Kanishka",Department="IT",Salary=56000,Experience=3},
                new Employee{EmpId=802,EmployeeName="Ananya",Department="Consultant",Salary=59000,Experience=5},
                new Employee{EmpId=803,EmployeeName="Manoranjitham",Department="Testing",Salary=44000,Experience=2},
                new Employee{EmpId=804,EmployeeName="Pravin",Department="AI",Salary=86000,Experience=7},
                new Employee{EmpId=805,EmployeeName="Sita",Department="IT",Salary=66000,Experience=6},
                new Employee{EmpId=806,EmployeeName="Riya",Department="HR",Salary=37000,Experience=2},
                new Employee{EmpId=807,EmployeeName="Reena",Department="Testing",Salary=22000,Experience=1},
                new Employee{EmpId=808,EmployeeName="Charu",Department="Developer",Salary=76000,Experience=4},
                new Employee{EmpId=809,EmployeeName="Chandra",Department="HR",Salary=96000,Experience=10},
                new Employee{EmpId=810,EmployeeName="Kathir",Department="Cybersecurity",Salary=55000,Experience=5},

            };
            PrintEmployeeDelegate printDel = ConsolePrint;
            Console.WriteLine("\n--- Employee Management System ---");
            Console.WriteLine("\n--- All Employees ---");

            foreach (var emp in employees)
            {
                printDel(emp);
            }
            Console.WriteLine("\n--- Employees with Salary  Greater than 50000 ---");
            DisplayEmployee(employees,e=>e.Salary>50000,printDel);
            Console.WriteLine("\n--- Employees in IT Department ---");
            DisplayEmployee(employees, e => e.Department == "IT", printDel);
            Console.WriteLine("\n--- Employees with Experience Greater than 5 years ---");
            DisplayEmployee(employees,e=>e.Experience>5,printDel);
            Console.WriteLine("\n--- Employee whose Name Start with 'A' ---");
            DisplayEmployee(employees, e => e.EmployeeName.StartsWith("A"), printDel);

            Console.WriteLine("\n--- Sort by Name (A–Z) ---");
            employees.Sort(new SortByName());
            foreach (var emp in employees)
                printDel(emp);

            Console.WriteLine("\n--- Sort by Salary High -> Low ---");
            employees.Sort(new SortBySalary());
            foreach (var emp in employees)
                printDel(emp);

            Console.WriteLine("\n--- Sort by Experience Low -> High ---");
            employees.Sort(new SortByExperience());
            foreach (var emp in employees)
                printDel(emp);

            Console.ReadLine();
        }


        public class SortByName : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                return x.EmployeeName.CompareTo(y.EmployeeName);
            }
        }

        public class SortBySalary : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                return y.Salary.CompareTo(x.Salary);
            }
        }

        public class SortByExperience : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                return x.Experience.CompareTo(y.Experience);
            }
        }
        public static void ConsolePrint(Employee e)
        {
            Console.WriteLine($"ID:{e.EmpId}, Name:{e.EmployeeName}, Dept:{e.Department}, Salary:{e.Salary}, Exp:{e.Experience} yrs");
        }
        public static void DisplayEmployee(List<Employee> employees, FilterEmployeeDelegate filter, PrintEmployeeDelegate printer)
        {
            foreach (var emp in employees)
            {
                if (filter(emp))
                    printer(emp);
            }
        
    }
    }
}
