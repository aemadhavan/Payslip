using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MYOB.EMP.Payslip;

namespace MYOB.EMP.Payslip.Tests
{   
   
    [TestClass()]
    public class UnitTestReadCSV
    {
        GetCSVFile objCSV = new GetCSVFile();

        [TestMethod()]
        public void GivenFileIsNotValidTest()
        {   
            //arrange         
            objCSV.FileName = @"C:\Users\madha\Documents\Visual Studio 2015\Projects\MYOB.EMP.Payslip\MYOB.EMP.Payslip\Employee.xls";//p.ReadFile();
            //act
            var result = objCSV.FileCheck();
            //assert
            Assert.AreEqual(false, result);
        }
        [TestMethod()]
        public void GivenFileWithoutFileNameTest()
        {
            objCSV.FileName = @"C:\Users\madha\Documents\Visual Studio 2015\Projects\MYOB.EMP.Payslip\MYOB.EMP.Payslip\";//p.ReadFile();
            var result = objCSV.FileCheck();
            Assert.AreEqual(false, result);
        }
        [TestMethod()]
        public void IsGivenFileNotCSVTest()
        {                        
            objCSV.FileName = @"C:\Users\madha\Downloads\CloudDesignPatternsBook-PDF.pdf"; // p.ReadFile();
            var result = objCSV.FileCheck();
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void IsGivenFileCSVTest()
        {
            objCSV.FileName = @"C:\Users\madha\Documents\Visual Studio 2015\Projects\MYOB.EMP.Payslip\MYOB.EMP.Payslip\Employee.csv"; // p.ReadFile();
            var result = objCSV.FileCheck();
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void CSVHasHeaderTest()
        {            
            objCSV.HeaderChar = "Y";
            Assert.AreEqual(true, objCSV.CSVHasHeader());
        }
        [TestMethod()]
        public void CSVHasNoHeaderTest()
        {
            objCSV.HeaderChar = "N";
            Assert.AreEqual(false, objCSV.CSVHasHeader());
        }
        [TestMethod()]
        public void CSVDataInFormatTest()
        {
            bool DataInFormat=objCSV.CSVDataInFormat("Madhavan,Ekanathan,60050,9%,01 March - 31 March");                       
            Assert.AreEqual(true, DataInFormat);
        }

        [TestMethod()]
        public void CSVDataNotInFormatTest()
        {
            //Arrange
            string[] InCorrectPatterns = { "Madhavan,Ekanathan,60050,9,01 March - 31 March", //Super Rate missing %
                                           ",Ekanatha,60050,9%,01 March - 31 March", //Missing First Name
                                           "Madhavan,,60050,9%,01 March - 31 March", //Missing Last Name
                                           "Madhavan,Ekanathan,,9%,01 March - 31 March", //Missing Annual Income
                                           "Madhavan,Ekanathan,60050,,01 March - 31 March", //Missing Super Rate
                                           "Madhavan,Ekanathan,60050,9%,", //Missing Pay Period
                                           "Madhavan,Ekanathan,60050,9%,01 Mar - 31 Mar", //Pay Period Month in Short Format
                                           "Madhavan,Ekanathan,60050,9%, - 31 Mar", //Pay Period Month has no start date
                                           "Madhavan,Ekanathan,60050,9%,01 Mar -", //Pay Period Month has no end date
                                           "Madhavan,Ekanathan,-60050,9%,01 Mar -", //Annual Income in Negative Value
                                           ",,,,", //Empty Pattern
                                           "" // Empty String
                                         };
            bool DataInFormat;
            foreach (string line in InCorrectPatterns)
            {
                //Act
                DataInFormat = objCSV.CSVDataInFormat(line); //super rate dont have %
                //Assert
                Assert.AreEqual(false, DataInFormat);
            }
            
        }
    }
}


