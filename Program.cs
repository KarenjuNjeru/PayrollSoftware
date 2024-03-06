using System;
using System.Collections.Generic;

namespace PayrollSoftware
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "PAYROLL SOFTWARE";

            List<Employee> employees = new List<Employee>();

            int choice;
            do
            {
                Console.WriteLine("PAYROLL SOFTWARE MENU");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Process Payroll");
                Console.WriteLine("3. View Employees");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddEmployee(employees);
                        break;
                    case 2:
                        ProcessPayroll(employees);
                        break;
                    case 3:
                        ViewEmployees(employees);
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }

                Console.WriteLine();
            } while (choice != 4);
        }

        static void AddEmployee(List<Employee> employees)
        {
            Console.WriteLine("Enter employee details:");
            Console.Write("Name: ");
            string name = Convert.ToString(Console.ReadLine());
            Console.Write("Position: ");
            string position = Console.ReadLine();
            Console.Write("Salary: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal salary))
            {
                Console.WriteLine("Invalid salary. Please enter a valid number.");
                return;
            }

            employees.Add(new Employee(name, position, salary));
            Console.WriteLine("Employee added successfully.");
        }

        static void ProcessPayroll(List<Employee> employees)
        {
            Console.WriteLine("Processing Payroll...");
            foreach (var employee in employees)
            {
                decimal salary = employee.CalculateSalary();
                Console.WriteLine($"Salary processed for {employee.Name}: {salary}");
            }
        }

        static void ViewEmployees(List<Employee> employees)
        {
            Console.WriteLine("EMPLOYEE LIST");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }

    class Employee
    {
        public string Name { get; }
        public string Position { get; }
        public decimal Salary { get; }

        public Employee(string name, string position, decimal salary)
        {
            Name = name;
            Position = position;
            Salary = salary;
        }

        public decimal CalculateSalary()
        {
            // Add any salary calculation logic here (e.g., deductions, bonuses)
            return Salary;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Position: {Position}, Salary: {Salary}";
        }
    }
}
