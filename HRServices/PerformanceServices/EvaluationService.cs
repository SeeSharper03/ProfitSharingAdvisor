using HRServices.EmployeeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRServices.PerformanceServices
{
    public class EvaluationService : IEvaluationService
    {
        /// <summary>Get Employee Evaluation
        /// <para>Gets the most recent employee evaluation for a given employee. This rating is randomly assigned.</para>
        /// </summary>
        public EmployeeEvaluation GetLatestEmployeeEvaluation(Employee employee)
        {
            return new EmployeeEvaluation { Employee = employee, Rating = (EvaluationRating)new Random().Next(1, 4) };
        }
    }
}
