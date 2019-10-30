using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arcaim.LoanCalculator.Core.Domains;
using Arcaim.LoanCalculator.Core.Repositories;
using Arcaim.LoanCalculator.Infrastructure.CreditFlows;

namespace Arcaim.LoanCalculator.Infrastructure.Services
{
    public class CreditService : ICreditService
    {
        private ICreditRepository _repository;
        private ICreditFlow _flow;
        private bool _newParams = false;

        public CreditService(ICreditRepository repository, ICreditFlow flow)
        {
            _repository = repository;
            _flow = flow;
        }

        public async Task<ICollection<FinancialResult>> GetFinancialResultAsync()
        {
            if (_newParams)
            {
                await _flow.Calculate(_repository);
            }

            return await _repository.GetFinancialResultAsync();
        }

        public async Task SetCreditFlowAsync(ICreditFlow flow)
        {
            _flow = flow;
            await Task.CompletedTask;
        }

        public async Task SetCreditAsync(decimal amountOfCredit, decimal annualLendingRate, int lifeOfLoan)
        {
            _newParams = true;
            var credit = await _repository.GetCreditAsync();

            if (credit != null)
            {
                if (credit.AmountOfCredit == amountOfCredit
                    && credit.AnnualLendingRate == annualLendingRate
                    && credit.LifeOfLoan == lifeOfLoan)
                {
                    _newParams = false;
                    return;
                }
            }

            await _repository.ClearAsync();
            await _repository.SetCreditAsync(new Credit {
                AmountOfCredit = amountOfCredit,
                AnnualLendingRate = annualLendingRate,
                LifeOfLoan = lifeOfLoan
            });
        }
    }
}