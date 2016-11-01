using System;
using EmployeeApplication.ConcreteSalaryCalculators;
using EmployeeApplication.Models;
using EmployeeApplication.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeTest
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void SalaryShouldBeProperlyCalculatedForIrelandEmployees()
        {
            var employee = new Employee { HourlyRate = 10, HoursWorked = 1, Location = "ireland" };
            var salaryCalculator = new EmployeeSalaryCalculator(new IrelandSalaryCalculator());
            var salary = salaryCalculator.CalculateSalary(employee);
            Assert.AreEqual(salary.GrossSalary, 10);
        }

        [TestMethod]
        public void IncomeTaxShouldBeProperlyDeductedForIrelandEmployees()
        {
            var employee = new Employee {HourlyRate = 1, HoursWorked = 1, Location = "ireland"};
            var salaryCalculator = new EmployeeSalaryCalculator(new IrelandSalaryCalculator());
            var salary = salaryCalculator.CalculateSalary(employee);
            Assert.AreEqual(salary.Deduction.IncomeTax,0.25);
        }

        [TestMethod]
        public void IncomeTaxShouldBeProperlyDeductedForIrelandEmployeesWhenSalaryIsMore()
        {
            var employee = new Employee { HourlyRate = 100, HoursWorked = 10, Location = "ireland" };
            var salaryCalculator = new EmployeeSalaryCalculator(new IrelandSalaryCalculator());
            var salary = salaryCalculator.CalculateSalary(employee);
            Assert.AreEqual(salary.Deduction.IncomeTax, 310);
        }

        [TestMethod]
        public void UniversalChargeShouldBeProperlyDeductedForIrelandEmployees()
        {
            var employee = new Employee { HourlyRate = 1, HoursWorked = 1, Location = "ireland" };
            var salaryCalculator = new EmployeeSalaryCalculator(new IrelandSalaryCalculator());
            var salary = salaryCalculator.CalculateSalary(employee);
            Assert.AreEqual(salary.Deduction.UniversalSocialCharge, 0.07);
        }

        [TestMethod]
        public void UniversalChargeShouldBeProperlyDeductedForIrelandEmployeesWhenSalaryIsMore()
        {
            var employee = new Employee { HourlyRate = 100, HoursWorked = 10, Location = "ireland" };
            var salaryCalculator = new EmployeeSalaryCalculator(new IrelandSalaryCalculator());
            var salary = salaryCalculator.CalculateSalary(employee);
            Assert.AreEqual(salary.Deduction.UniversalSocialCharge, 75);
        }

        [TestMethod]
        public void CompulsoryPensionShouldBeProperlyDeductedForIrelandEmployees()
        {
            var employee = new Employee { HourlyRate = 1, HoursWorked = 1, Location = "ireland" };
            var salaryCalculator = new EmployeeSalaryCalculator(new IrelandSalaryCalculator());
            var salary = salaryCalculator.CalculateSalary(employee);
            Assert.AreEqual(salary.Deduction.Pension, 0.04);
        }

        [TestMethod]
        public void IncomeTaxShouldBeProperlyDeductedForItalyEmployees()
        {
            var employee = new Employee { HourlyRate = 1, HoursWorked = 1, Location = "italy" };
            var salaryCalculator = new EmployeeSalaryCalculator(new ItalaySalaryCalculator());
            var salary = salaryCalculator.CalculateSalary(employee);
            Assert.AreEqual(salary.Deduction.IncomeTax, 0.25);
        }

        [TestMethod]
        public void SocialSecurityShouldBeProperlyDeductedForItalyEmployees()
        {
            var employee = new Employee { HourlyRate = 1, HoursWorked = 1, Location = "italy" };
            var salaryCalculator = new EmployeeSalaryCalculator(new ItalaySalaryCalculator());
            var salary = salaryCalculator.CalculateSalary(employee);
            Assert.AreEqual(salary.Deduction.SocialSecurityContribution, 0.0919);
        }

        [TestMethod]
        public void IncomeTaxShouldBeProperlyDeductedForGermanyEmployees()
        {
            var employee = new Employee { HourlyRate = 1, HoursWorked = 1, Location = "germany" };
            var salaryCalculator = new EmployeeSalaryCalculator(new GermanySalaryCalculator());
            var salary = salaryCalculator.CalculateSalary(employee);
            Assert.AreEqual(salary.Deduction.IncomeTax, 0.25);
        }

        [TestMethod]
        public void IncomeTaxShouldBeProperlyDeductedForGermanyEmployeesIfSalaryIsMore()
        {
            var employee = new Employee { HourlyRate = 100, HoursWorked = 10, Location = "germany" };
            var salaryCalculator = new EmployeeSalaryCalculator(new GermanySalaryCalculator());
            var salary = salaryCalculator.CalculateSalary(employee);
            Assert.AreEqual(salary.Deduction.IncomeTax, 292);
        }

        [TestMethod]
        public void PensionShouldBeProperlyDeductedForGermanyEmployees()
        {
            var employee = new Employee { HourlyRate = 1, HoursWorked = 1, Location = "germany" };
            var salaryCalculator = new EmployeeSalaryCalculator(new GermanySalaryCalculator());
            var salary = salaryCalculator.CalculateSalary(employee);
            Assert.AreEqual(salary.Deduction.Pension, 0.02);
        }
    }
}
