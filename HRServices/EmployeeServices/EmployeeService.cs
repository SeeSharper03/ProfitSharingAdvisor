using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRServices.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        /// <summary>Get List of Employees
        /// <para>Provides a list of current employees</para>
        /// </summary>
        public IEnumerable<Employee> ListEmployees()
        {
            return new List<Employee>()
            { new Employee { Id = 1, Employee_Name = "Jean-Luc Picard", Employee_Salary = 300000, Employee_Age = 59 , Profile_Image = string.Empty },
                { new Employee { Id = 2, Employee_Name = "William T. Riker", Employee_Salary = 120000, Employee_Age = 28,  Profile_Image = string.Empty } },
                { new Employee { Id = 3, Employee_Name = "Geordie La Forge", Employee_Salary = 500000, Employee_Age = 32,  Profile_Image = string.Empty } },
                { new Employee { Id = 4, Employee_Name = "Beverly Crusher", Employee_Salary = 200000, Employee_Age = 35,  Profile_Image = string.Empty } },
                { new Employee { Id = 5, Employee_Name = "Data", Employee_Salary = 175000, Employee_Age = 475,  Profile_Image = string.Empty } },
                { new Employee { Id = 6, Employee_Name = "Worf", Employee_Salary = 135000, Employee_Age = 32,  Profile_Image = string.Empty } },
                { new Employee { Id = 7, Employee_Name = "Deanna Troi", Employee_Salary = 500000, Employee_Age = 33,  Profile_Image = string.Empty } },
                { new Employee { Id = 8, Employee_Name = "Wesley Crusher", Employee_Salary = 10000, Employee_Age = 15,  Profile_Image = string.Empty } },
            };
        }
    }
}
