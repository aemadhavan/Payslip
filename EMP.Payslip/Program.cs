using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EMP.Payslip
{
    
    public class Program
    {
        public static string fileName;
       
        static void Main(string[] args)
        {            
            try
            {
                GetCSVFile objGetCSV = new GetCSVFile();
                Console.WriteLine(@"Enter the CSV with File Path (eg: C:\Users\Madhavan\Documents\Employee.csv): ");
                objGetCSV.ReadFile();
                objGetCSV.CSVGetHeaderInfo();


                if (objGetCSV.FileCheck())
                {
                   List<EmpPayslip> lstEmployeePay = objGetCSV.CSVDataRead(objGetCSV.CSVHasHeader());
                    Console.WriteLine();   
                    foreach(EmpPayslip ps in lstEmployeePay)
                    {
                        Console.WriteLine(ps.DisplayPayslip());
                    }
                }                  
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
