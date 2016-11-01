using System;
using EmployeeApplication.Interfaces;
using EmployeeApplication.Models;

namespace EmployeeApplication.ConcreteSalaryCalculators
{
    public class NormalSalaryCalculator : ISalaryCalculator
    {
        public Salary CalculateSalary(double hoursWorked, double hourlyRate)
        {
            var grossSalary = hoursWorked * hourlyRate;

            var salary = new Salary
            {
                GrossSalary = grossSalary,
                NetIncome = grossSalary
            };

            return salary;
           
        }
    }
}