using System.Collections.Generic;
using HRServices.PerformanceServices;

namespace HRServices.EmployeeServices
{
    public interface IEmployeeService
    {
        /// <summary>Get List of Employees
        /// <para>Provides a list of current employees</para>
        /// </summary>
        public IEnumerable<Employee> ListEmployees();
    }
}
