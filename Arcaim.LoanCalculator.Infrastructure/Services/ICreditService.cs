using System.Collections.Generic;
using System.Threading.Tasks;
using Arcaim.LoanCalculator.Core.Domains;
using Arcaim.LoanCalculator.Infrastructure.CreditFlows;

namespace Arcaim.LoanCalculator.Infrastructure.Services
{
    public interface ICreditService
    {
        Task<ICollection<FinancialResult>> GetFinancialResultAsync();
        Task SetCreditFlowAsync(ICreditFlow method);
        Task SetCreditAsync(decimal amountOfCredit, decimal annualLendingRate, int lifeOfLoan);
    }
}