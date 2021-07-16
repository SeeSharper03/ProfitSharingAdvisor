using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProfitSharingAdvisor.Extentions;
using ProfitSharingAdvisor.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using HRServices.EmployeeServices;
using HRServices.IncentiveServices;
using HRServices.PerformanceServices;

namespace ProfitSharingAdvisor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly ITargetBonusService _targetBonusService;
        private readonly IEvaluationService _evaluationService;

        public HomeController(ILogger<HomeController> logger, IEmployeeService employeeService, ITargetBonusService targetBonusService, IEvaluationService evaluationService)
        {
            _logger = logger;
            _employeeService = employeeService;
            _targetBonusService = targetBonusService;
            _evaluationService = evaluationService;
        }
        /// <summary>
        /// <para>Loads initial view providing a histogram of current employee salaries along with proposed bonuses based on their most recent employee evaluation rating ordered by employee name using a bubble sort.</para>
        /// </summary>
        public IActionResult Index()
        {
            var employees = _employeeService.ListEmployees();
            var employeeBonusProposals = new List<BonusProposal>();
            foreach(var employee in employees)
            {
                var currentEmployeeEvaluation = _evaluationService.GetLatestEmployeeEvaluation(employee);
                var targetBonus = _targetBonusService.GetTargetBonus(currentEmployeeEvaluation.Rating);
                employeeBonusProposals.Add(new BonusProposal(employee, currentEmployeeEvaluation.Rating, targetBonus));
            }
            var model = new HomeViewModel() { BonusProposals = employeeBonusProposals.BubbleSort(b=>b.Employee.Employee_Name) };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
