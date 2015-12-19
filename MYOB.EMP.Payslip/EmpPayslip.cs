using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYOB.EMP.Payslip
{
    public class EmpPayslip : EmpPaymentData, ICalculateIncomeTax, IDisplayPayslip
    {
        public double GrossIncome { get; set; }
        public double IncomeTax { get; set; }
        public double NetIncome { get; set; }
        public double Super { get; set; }

        public EmpPayslip():base() { }
        public EmpPayslip(string firstName, string lastName, double annualSalary, double superRate, string payPeriod) : base(firstName, lastName, annualSalary, superRate, payPeriod)
        {
            GrossIncome = annualSalary / 12;
            IncomeTax = CalculateIncomeTax(Convert.ToDouble(annualSalary));
            NetIncome = GrossIncome - IncomeTax;
            Super = GrossIncome * superRate / 100;
        }
        public double CalculateIncomeTax(double annualSalary)
        {
            var map = new Dictionary<Func<double, bool>, double>()
            {
                { d => d >= 0 && d <= 18200, 0.0 },
                { d => d >= 18201 && d <= 37000, (annualSalary-18000)* 0.19 },
                { d => d >= 37001 && d <= 80000, (3572+(annualSalary-37000)*0.325) },
                { d => d >= 80001 && d <= 180000, (17547+(annualSalary-80000)*0.37) },
                { d => d >= 180001,(54547+(annualSalary-180000)* 0.45) },
            };
            var key = map.Keys.Single(test => test(annualSalary));
            var value = map[key];
            return Convert.ToDouble(value / 12);
        }
        public void DisplayPayslip(List<EmpPayslip> lstPaySlip)
        {
            foreach (EmpPayslip ps in lstPaySlip)
            {
                Console.WriteLine(ps.FirstName + ", " + 
                                   ps.LastName + ", " + 
                                   Math.Round(ps.GrossIncome, 0) + ", " + 
                                   Math.Round(ps.IncomeTax, 0) + ", " + 
                                   Math.Round(ps.NetIncome, 0) + ", " + 
                                   Math.Round(ps.Super, 0));
            }
        }
        public string DisplayPayslip()
        {            
                return(FirstName + ", " +LastName + ", " +Math.Round(GrossIncome, 0).ToString("C0") + ", " +
                       Math.Round(IncomeTax, 0).ToString("C0") + ", " +Math.Round(NetIncome, 0).ToString("C0") + ", " +
                                   Math.Round(Super, 0).ToString("C0"));            
        }
    }
}
