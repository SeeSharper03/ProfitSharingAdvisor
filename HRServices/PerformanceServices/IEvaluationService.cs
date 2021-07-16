using HRServices.EmployeeServices;

namespace HRServices.PerformanceServices
{
    public interface IEvaluationService
    {
        /// <summary>Get Employee Evaluation
        /// <para>Gets the most recent employee evaluation for a given employee.</para>
        /// </summary>
        public EmployeeEvaluation GetLatestEmployeeEvaluation(Employee employee);
    }
}
