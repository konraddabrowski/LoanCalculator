using System;

namespace Arcaim.LoanCalculator.Core.Domains
{
    public class FinancialResult
    {
        public string MonthNumber { get; set; }
        // public string Installment { get; set; }
        public string CapitalPartOfInstallment { get; set; }
        public string InterestPartOfInstallment { get; set; }
        public string CapitalToRepay { get; set; }
        public string InterestToRepay { get; set; }
    }
}