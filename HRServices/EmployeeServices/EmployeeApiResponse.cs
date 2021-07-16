using System.Collections.Generic;

namespace HRServices.EmployeeServices
{
    public class EmployeeApiResponse
    {
        public string Status { get; set; }
        public IEnumerable<Employee> Data { get; set; }
        public string Message { get; set; }
    }
}
