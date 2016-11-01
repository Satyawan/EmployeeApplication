using EmployeeApplication.Interfaces;
using EmployeeApplication.Models;

namespace EmployeeApplication.Services
{
    public class EmployeeSalaryCalculator
    {
        public ISalaryCalculator SalaryCalculator;

        public EmployeeSalaryCalculator(ISalaryCalculator salaryCalulator)
        {
            SalaryCalculator = salaryCalulator;
        }
      

        public Salary CalculateSalary(Employee employee)
        {
            return SalaryCalculator.CalculateSalary(employee.HoursWorked,employee.HourlyRate);
        }


    }
}
