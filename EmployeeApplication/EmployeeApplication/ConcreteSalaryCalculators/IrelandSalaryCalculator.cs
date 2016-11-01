using System;
using EmployeeApplication.Interfaces;
using EmployeeApplication.Models;

namespace EmployeeApplication.ConcreteSalaryCalculators
{
    public class IrelandSalaryCalculator : ISalaryCalculator
    {

        public Salary CalculateSalary(double hoursWorked, double hourlyRate)
        {
            var grossSalary = hoursWorked * hourlyRate;

            var salary = new Salary
            {
                GrossSalary = grossSalary,
                Deduction = new Deduction
                {   
                    IncomeTax = grossSalary > 600
                    ? .25 * 600 + (grossSalary - 600) * .40
                    : .25 * grossSalary,
                    UniversalSocialCharge = grossSalary > 500
                    ? .07 * 500 + (grossSalary - 500) * .08
                    : .07 * grossSalary,
                    Pension = .04 * grossSalary
                }
            };

            salary.NetIncome = salary.GrossSalary - (salary.Deduction.IncomeTax + salary.Deduction.UniversalSocialCharge + salary.Deduction.Pension);

            return salary;

        }
    }
}