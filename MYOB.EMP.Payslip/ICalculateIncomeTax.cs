using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMP.Payslip
{
    public interface ICalculateIncomeTax
    {
        double CalculateIncomeTax(double annualSalary);
    }
}
