using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MYOB.EMP.Payslip;

namespace MYOB.EMP.Payslip.Tests
{
   
    [TestClass()]
    public class UnitTestPayslip
    {
        EmpPayslip objPS = new EmpPayslip("Madhavan", "Ekanathan", 60050, 9, "01 March - 31 March");
        
        [TestMethod()]
        public void CalculatedGrosspayValueTest()
        {
            Assert.AreEqual(5004, Math.Round(objPS.GrossIncome));
        }
        [TestMethod()]
        public void CalculateIncomeTaxTest()
        {
            Assert.AreEqual(922, Math.Round(objPS.CalculateIncomeTax(objPS.AnnualSalary)));
        }
        [TestMethod()]
        public void CalculatedIncomeTaxValueTest()
        {
            Assert.AreEqual(922, Math.Round(objPS.IncomeTax));
        }
        [TestMethod()]
        public void CalculatedNetIncomeValueTest()
        {   
            Assert.AreEqual(4082, Math.Round(objPS.NetIncome));
        }
        [TestMethod()]
        public void CalculatedSuperValueTest()
        {   
            Assert.AreEqual(450, Math.Round(objPS.Super));
        }
    }

    
}


