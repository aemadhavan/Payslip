using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMP.Payslip
{
    public interface IDisplayPayslip
    {
        void DisplayPayslip(List<EmpPayslip> ps);
    }
}
