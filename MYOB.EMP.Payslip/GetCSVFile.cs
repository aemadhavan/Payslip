using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MYOB.EMP.Payslip
{
    public class GetCSVFile
    {
        public string FileName { get; set; }
        public bool HasHeader { get; set; }
        public string HeaderChar { get; set; }

        public List<EmpPayslip> lstEmployeePaySlips = new List<EmpPayslip>();
        public string ReadFile()
        {
            FileName= Console.ReadLine();
            return FileName;
        }
        public void CSVGetHeaderInfo()
        {
            bool correctInput = false;
            do
            {
                Console.WriteLine(@"Does the CSV has header row: (Y/N): ");
                HeaderChar = Console.ReadLine().ToUpper();
                if (HeaderChar == "Y" || HeaderChar == "N")
                {                    
                    correctInput = true;
                }
                else
                {
                    correctInput = false;
                }

            } while (!correctInput);
        }
        public bool FileCheck()
        {

            if (File.Exists(FileName))
            {
                FileInfo fi = new FileInfo(FileName);
                if (fi.Extension.ToUpper() == ".CSV")
                {                    
                    return true;
                }
                else
                {
                    Console.WriteLine("Please provide the CSV file");
                    return false;
                }
            }
            else {
                Console.WriteLine("File specified in the path doesn't exist.");
                return false;
            }

        }
        public bool CSVHasHeader()
        {            
            HasHeader = (HeaderChar.ToUpper() == "Y") ? true : false;
            return HasHeader;
        }
        public  List<EmpPayslip> CSVDataRead(bool hasHeader)
        {
            string line = string.Empty;
            string[] lineValue = { string.Empty };
            int inCorrectLines = 0, correctLine = 0;

            using (StreamReader streamReader = new StreamReader(FileName))
            {
                if (HasHeader) streamReader.ReadLine();

                while ((line = streamReader.ReadLine()) != null)
                {
                    
                    if (CSVDataInFormat(line))
                    {                        
                        lineValue = line.Split(',');
                        
                        try
                        {
                            string firstName = lineValue[0];
                            string lastName = lineValue[1];
                            double annualSalary = Convert.ToDouble(lineValue[2]);
                            double superRate = Convert.ToDouble(lineValue[3].Split('%')[0]);
                            string payPeriod = lineValue[4];
                            EmpPayslip objEMPPayslip = new EmpPayslip(firstName,lastName,annualSalary,superRate,payPeriod);
                            lstEmployeePaySlips.Add(objEMPPayslip);                            
                            correctLine++;
                        }
                        catch (Exception ex)
                        {
                            inCorrectLines++;
                        }
                    }
                    else
                    {
                        inCorrectLines++;
                    }
                }
                Console.WriteLine("Total Records: " + (correctLine + inCorrectLines).ToString());
                Console.WriteLine("Records with Correct Format: " + correctLine.ToString());
                Console.WriteLine("Records with Incorrect Format: " + inCorrectLines.ToString());
            }
            return lstEmployeePaySlips;
        }
        public bool CSVDataInFormat(string line)
        {
            string Months = @"January|February|March|April|May|June|July|Auguest|Septemper|October|November|December";
            string pattern = @"^(\w)+\,(\w)+\,(\d)+\,(\d)+%\,01\s(" + Months + @")\s-\s(28|29|30|31)\s(" + Months + ")$";
            Match result = Regex.Match(line, pattern);
            return result.Success;
        }
    }
}
