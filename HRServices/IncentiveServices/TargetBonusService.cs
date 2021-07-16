using HRServices.PerformanceServices;

namespace HRServices.IncentiveServices
{
    public class TargetBonusService : ITargetBonusService
    {
        /// <summary>Get Target Bonus
        /// <para>Provides a target bonus based on an employee's evaluation rating</para>
        /// </summary>
        public decimal GetTargetBonus(EvaluationRating employeeEvaluationRating)
        {
            switch(employeeEvaluationRating)
            {
                case EvaluationRating.MeetsExpectations:
                    return 0.05M;
                case EvaluationRating.ExceedsExpectations:
                    return 0.15M;
                case EvaluationRating.SignficantlyExceedsExpectations:
                    return 0.25M;
            }
            return 0;
        }
    }
}
