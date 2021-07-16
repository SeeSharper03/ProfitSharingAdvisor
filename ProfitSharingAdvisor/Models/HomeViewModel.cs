using HRServices.EmployeeServices;
using HRServices.IncentiveServices;
using System.Collections.Generic;

namespace ProfitSharingAdvisor.Models
{
    public class HomeViewModel
    {
        public IEnumerable<BonusProposal> BonusProposals { get; set; }
    }
}
