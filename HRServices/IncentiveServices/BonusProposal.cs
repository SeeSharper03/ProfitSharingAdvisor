using HRServices.EmployeeServices;
using HRServices.PerformanceServices;

namespace HRServices.IncentiveServices
{
    public class BonusProposal
    {
        public Employee Employee { get; }
        public EvaluationRating Rating { get; }
        public decimal TargetBonus { get; }
        public decimal ProposedBonusAmount { get { return this.Employee.Employee_Salary * this.TargetBonus; } }

        public BonusProposal(Employee employee, EvaluationRating rating, decimal targetBonus)
        {
            this.Employee = employee;
            this.Rating = rating;
            this.TargetBonus = targetBonus;
        }

    }
}
