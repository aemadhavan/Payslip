using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYOB.EMP.Payslip
{
    public class EmpPaymentData : Employee
    {
        public double AnnualSalary { get; set; }        
        public double SuperRate { get; set; }
        public string PayPeriod { get; set; }

        public EmpPaymentData():base() { }
        public EmpPaymentData(string firstName, string lastName, double annualSalary, double superRate, string payPeriod):base(firstName,lastName)
        {
            AnnualSalary = annualSalary;
            SuperRate = superRate;
            PayPeriod = payPeriod;
        }
    }
}
