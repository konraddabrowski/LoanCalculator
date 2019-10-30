using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcaim.LoanCalculator.Core.Domains;
using Arcaim.LoanCalculator.Core.Repositories;

namespace Arcaim.LoanCalculator.Infrastructure.Repositories
{
    public class CreditRepository : ICreditRepository
    {
        private Credit _credit;
        private ICollection<FinancialResult> _financialResults = new List<FinancialResult>();

        public async Task AddFinancialResultAsync(FinancialResult financialResult)
        {
            _financialResults.Add(financialResult);
            await Task.CompletedTask;
        }

        public async Task ClearAsync()
        {
            _credit = null;
            _financialResults.Clear();
            await Task.CompletedTask;
        }

        public async Task<Credit> GetCreditAsync()
            => await Task.FromResult(_credit);

        public async Task<ICollection<FinancialResult>> GetFinancialResultAsync()
            => await Task.FromResult(_financialResults);

        public async Task SetCreditAsync(Credit credit)
        {
            _credit = credit;
            await Task.CompletedTask;
        }
    }
}