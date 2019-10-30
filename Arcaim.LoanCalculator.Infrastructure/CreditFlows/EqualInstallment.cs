using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arcaim.LoanCalculator.Core.Domains;
using Arcaim.LoanCalculator.Core.Repositories;
using Arcaim.LoanCalculator.Infrastructure.Exensions;

namespace Arcaim.LoanCalculator.Infrastructure.CreditFlows
{
    public class EqualInstallment : ICreditFlow
    {
        public async Task Calculate(ICreditRepository repository)
        {
            var credit = await repository.GetCreditAsync();

            bool isFirst = true;
            decimal priorInterestToRepay = 0;
            var debt = credit.AmountOfCredit;
            var k = credit.AnnualLendingRate/1200;
            var q = 1 + k;
            var qPowLol = q.Pow(credit.LifeOfLoan);
            int month = 1;
            
            var installment = debt*qPowLol*(q-1)/(qPowLol-1); // rata
            var results = new List<FinancialResult>();

            while(debt > 1)
            {
                var result = new FinancialResult();
                result.MonthNumber = month.ToString();
                result.InterestPartOfInstallment = (debt*k).Stringify(); // odsetki będące częścią raty
                result.CapitalPartOfInstallment = (installment - debt*k).Stringify(); // kapitał do spłacenia będący częścią raty
                result.CapitalToRepay = (debt - installment + debt*k).Stringify();
                priorInterestToRepay = isFirst
                    ? installment * credit.LifeOfLoan - debt - debt*k
                    : priorInterestToRepay - debt*k;
                result.InterestToRepay = priorInterestToRepay.Stringify();
                // result.Installment = (debt*k).RoundTo2() + (installment - debt*k).RoundTo2() > installment.RoundTo2()
                //     ? (installment.RoundTo2() + 0.01m).Stringify()
                //     : installment.RoundTo2().Stringify();
                debt = debt - installment + debt*k;
                isFirst = false;
                month++;
                await repository.AddFinancialResultAsync(result);
            } 
        }
    }
}