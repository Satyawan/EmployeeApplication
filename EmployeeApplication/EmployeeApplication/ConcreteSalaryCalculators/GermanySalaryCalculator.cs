using EmployeeApplication.Interfaces;
using EmployeeApplication.Models;

namespace EmployeeApplication.ConcreteSalaryCalculators
{
    public class GermanySalaryCalculator : ISalaryCalculator
    {
        public Salary CalculateSalary(double hoursWorked, double hourlyRate)
        {
            var grossSalary = hoursWorked*hourlyRate;

            var salary = new Salary
            {
                GrossSalary = grossSalary,
                Deduction = new Deduction
                {
                    IncomeTax = grossSalary > 400
                    ? .25 * 400 + (grossSalary - 400) * .32
                    : .25 * grossSalary,

                    Pension = .02 * grossSalary
                }
            };

            salary.NetIncome = salary.GrossSalary - (salary.Deduction.IncomeTax + salary.Deduction.Pension);

            return salary;
        }
    }
}