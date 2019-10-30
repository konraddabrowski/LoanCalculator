using System.Collections.Generic;
using System.Threading.Tasks;
using Arcaim.LoanCalculator.Core.Domains;

namespace Arcaim.LoanCalculator.Core.Repositories
{
    public interface ICreditRepository
    {
        Task AddFinancialResultAsync(FinancialResult financialResult);
        Task ClearAsync();
        Task<Credit> GetCreditAsync();
        Task<ICollection<FinancialResult>> GetFinancialResultAsync();
        Task SetCreditAsync(Credit credit);
    }
}