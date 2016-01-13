using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMP.Payslip
{
    public class Employee 
        {
            string firstName;
            string lastName;            

            public string FirstName
            {
                get { return firstName; }
                set { this.firstName = value; }
            }
            public string LastName
            {
                get { return lastName; }
                set { this.lastName = value; }
            }
            public Employee()
            { }            
            public Employee(string firstName,string lastName)
            {
            FirstName = firstName;
            LastName = lastName;
            }
        }    
}
