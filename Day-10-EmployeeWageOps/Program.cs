// See https://aka.ms/new-console-template for more information

//Employee Wage FInal Solution 

using static Day_10_EmployeeWageOps.CompanyWageBuilder;

Console.WriteLine("----- Welcome to Employee Wage Monitoring System -----\n");

EmpWageBuilder obj = new EmpWageBuilder();
obj.AddCompanyWage("Google", 40, 20, 100);
obj.AddCompanyWage("Apple", 20, 20, 100);
obj.ComputeEmpWage();