using Microsoft.AspNetCore.Mvc;
using HRServices.EmployeeServices;
using System.Linq;
using ProfitSharingAdvisor.Extentions;

namespace ProfitSharingAdvisor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        /// <summary>
        /// <para>Provides list of employees and their salaries sorted by salary in descending order using a bubble sort.</para>
        /// </summary>
        [HttpGet]
        public JsonResult Get()
        {
            var employeeList = _employeeService.ListEmployees().ToList().BubbleSortDesc(e => e.Employee_Salary);
            return new JsonResult(employeeList);
        }
    }
}
