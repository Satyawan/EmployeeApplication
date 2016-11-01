using System;
using EmployeeApplication.ConcreteSalaryCalculators;
using EmployeeApplication.Interfaces;
using EmployeeApplication.Models;
using EmployeeApplication.Services;

namespace EmployeeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                double totalHoursWorked = GetTotalHoursWorked();

                double hourlyRate = GetHourlyRate();

                string location = GetLocation();

                var calculatorType = GetCalculatorType(location);
                var calculator = new EmployeeSalaryCalculator(calculatorType);

                var employee = new Employee
                {
                    HoursWorked = totalHoursWorked,
                    HourlyRate = hourlyRate,
                    Location = location
                };

                employee.Salary = calculator.CalculateSalary(employee);

                PrintResults(employee);
                
                Console.WriteLine("Do you want to continue? (y/n)");

            } while (Console.ReadLine() != "n");
        }

        private static void PrintResults(Employee employee)
        {
            Console.WriteLine($"Gross Amount : ${employee.Salary.GrossSalary}");

            if (employee.Salary.Deduction != null)
            {
                Console.WriteLine("Less deductions");
                if (employee.Salary.Deduction.IncomeTax.HasValue)
                    Console.WriteLine($"Income Tax : ${employee.Salary.Deduction.IncomeTax}");
                if (employee.Salary.Deduction.UniversalSocialCharge.HasValue)
                    Console.WriteLine($"Universal Social Charge : ${employee.Salary.Deduction.UniversalSocialCharge}");
                if (employee.Salary.Deduction.SocialSecurityContribution.HasValue)
                    Console.WriteLine($"Social Security Contribution : ${employee.Salary.Deduction.SocialSecurityContribution}");
                if (employee.Salary.Deduction.Pension.HasValue)
                    Console.WriteLine($"Pension : ${employee.Salary.Deduction.Pension}");

            }
            
            Console.WriteLine($"Net Amount : ${employee.Salary.NetIncome}");
        }

        private static string GetLocation()
        {
            Console.WriteLine("Please enter the employee location");
            var location = Console.ReadLine();
            return location;
        }

        private static double GetHourlyRate()
        {
            Console.WriteLine("Please enter the hourly rate");
            double hourlyRate;
            while (!Double.TryParse(Console.ReadLine(), out hourlyRate))
            {
                Console.WriteLine("Please enter a proper value");
                Console.WriteLine("Please enter the hourly rate");
            }
            return hourlyRate;
        }

        private static double GetTotalHoursWorked()
        {
            Console.WriteLine("Please enter the hours worked");
            double totalHoursWorked;
            while (!Double.TryParse(Console.ReadLine(), out totalHoursWorked))
            {
                Console.WriteLine("Please enter a proper value");
                Console.WriteLine("Please enter the hours worked");
            }
            return totalHoursWorked;
            
        }

        private static ISalaryCalculator GetCalculatorType(string location)
        {
            ISalaryCalculator calculator;
            switch (location.Trim().ToLower())
            {
                case "ireland":
                    calculator = new IrelandSalaryCalculator();
                    break;
                case "italy":
                    calculator = new ItalaySalaryCalculator();
                    break;
                case "germany":
                    calculator = new GermanySalaryCalculator();
                    break;
                default:
                    calculator = new NormalSalaryCalculator();
                    break;
            }
            return calculator;
        }
    }
}
