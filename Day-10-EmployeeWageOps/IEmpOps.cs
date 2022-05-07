using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10_EmployeeWageOps
{
    internal interface IEmpOps
    {
        public void AddCompanyWage(string Company, int EmpRatePerHr, int MaxWorkingDaysPerMonth, int MaxWorkingHrPerMonth);

        public void ComputeEmpWage();

        public int GetTotalWage(string Company);


    }
}
