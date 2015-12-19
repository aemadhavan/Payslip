using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYOB.EMP.Payslip
{
    public interface IDisplayPayslip
    {
        void DisplayPayslip(List<EmpPayslip> ps);
    }
}
