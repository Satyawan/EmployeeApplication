using System;
using EmployeeApplication.Interfaces;
using EmployeeApplication.Models;

namespace EmployeeApplication.ConcreteSalaryCalculators
{
    public class ItalaySalaryCalculator : ISalaryCalculator
    {
        public Salary CalculateSalary(double hoursWorked, double hourlyRate)
        {
            var grossSalary = hoursWorked * hourlyRate;

            var salary = new Salary
            {
                GrossSalary = grossSalary,
                Deduction =  new Deduction
                {
                    IncomeTax = .25 * grossSalary,
                    SocialSecurityContribution = .0919 * grossSalary
                }
            };
            salary.NetIncome = salary.GrossSalary - (salary.Deduction.IncomeTax + salary.Deduction.SocialSecurityContribution );

            return salary;
            
        }
    }
}