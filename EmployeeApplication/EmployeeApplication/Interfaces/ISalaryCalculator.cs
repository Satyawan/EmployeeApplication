using EmployeeApplication.Models;

namespace EmployeeApplication.Interfaces
{
    public interface ISalaryCalculator
    {
        Salary CalculateSalary(double hoursWorked, double hourlyRate);
    }
}