using HRServices.PerformanceServices;

namespace HRServices.IncentiveServices
{
    public interface ITargetBonusService
    {
        /// <summary>Get Target Bonus
        /// <para>Provides a target bonus based on an employee's evaluation rating</para>
        /// </summary>
        public decimal GetTargetBonus(EvaluationRating employeeEvaluationRating);
    }
}
