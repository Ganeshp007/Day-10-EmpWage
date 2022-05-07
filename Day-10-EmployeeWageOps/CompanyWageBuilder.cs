using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10_EmployeeWageOps
{
    internal class CompanyWageBuilder
    {

        public class CompanyEmpWage
        {
            public int EmpRatePerHr;
            public int MaxWorkingDaysPerMonth;
            public int MaxWorkingHrPerMonth;
            public int TotalWage;
            public string Company;

            public CompanyEmpWage(String Company, int EmpRatePerHr, int MaxWorkingDaysPerMonth, int MaxWorkingHrPerMonth)
            {
                this.Company = Company;
                this.EmpRatePerHr = EmpRatePerHr;
                this.MaxWorkingDaysPerMonth = MaxWorkingDaysPerMonth;
                this.MaxWorkingHrPerMonth = MaxWorkingHrPerMonth;
                this.TotalWage = 0;

            }

            public void SetTotalWage(int TotalWage)
            {
                this.TotalWage = TotalWage;
            }

            public String tostring()
            {
                return "\nTotal Employee Wage for Comapnay " + this.Company + " is :-" + this.TotalWage + "\n";
            }
        }

        public class EmpWageBuilder : IEmpOps
        {
            public const int IS_Parttime = 1;
            public const int IS_FUlltime = 2;

            private LinkedList<CompanyEmpWage> CompanyEmpWageList;
            private Dictionary<string, CompanyEmpWage> CompanyEmpWageMap;



            public EmpWageBuilder()
            {
                this.CompanyEmpWageList = new LinkedList<CompanyEmpWage>();
                this.CompanyEmpWageMap = new Dictionary<string, CompanyEmpWage>();
            }

            public void AddCompanyWage(string Company, int EmpRatePerHr, int MaxWorkingDaysPerMonth, int MaxWorkingHrPerMonth)
            {
                CompanyEmpWage obj = new CompanyEmpWage(Company, EmpRatePerHr, MaxWorkingDaysPerMonth, MaxWorkingHrPerMonth);
                this.CompanyEmpWageList.AddLast(obj);
                this.CompanyEmpWageMap.Add(Company, obj);

            }

            public void ComputeEmpWage()
            {
                foreach (CompanyEmpWage obj in this.CompanyEmpWageList)
                {
                    obj.SetTotalWage(this.ComputeEmpWage(obj));
                    Console.WriteLine(obj.tostring());
                }
            }

            private int ComputeEmpWage(CompanyEmpWage obj)
            {
                int empHr = 0, totalempHR = 0, totalworkingdays = 0;

                while (totalworkingdays <= obj.MaxWorkingDaysPerMonth && totalempHR <= obj.MaxWorkingHrPerMonth)
                {
                    totalworkingdays++;
                    Random r = new Random();
                    int empcheck = r.Next(0, 3);

                    switch (empcheck)
                    {
                        case IS_FUlltime: empHr = 8; break;

                        case IS_Parttime: empHr = 4; break;

                        default: empHr = 0; break;
                    }
                    totalempHR += empHr;

                    Console.WriteLine("Day:- " + totalworkingdays + "  Working Hours:- " + empHr);
                }
                return totalempHR * obj.EmpRatePerHr;
            }



            public int GetTotalWage(string Company)
            {
                return this.CompanyEmpWageMap[Company].TotalWage;
            }





        }
    }
}