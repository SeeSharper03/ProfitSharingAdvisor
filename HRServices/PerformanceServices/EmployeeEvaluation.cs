using HRServices.EmployeeServices;

namespace HRServices.PerformanceServices
{
    public enum EvaluationRating
    {
        NeedsImprovement = 1,
        MeetsExpectations = 2,
        ExceedsExpectations = 3,
        SignficantlyExceedsExpectations = 4
    }
    public class EmployeeEvaluation
    {
        public Employee Employee { get; set; }
        public EvaluationRating Rating { get; set; }
    }
}
