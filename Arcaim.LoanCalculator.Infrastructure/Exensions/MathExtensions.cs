using System;

namespace Arcaim.LoanCalculator.Infrastructure.Exensions
{
    public static class MathExtensions
    {
        public static decimal RoundTo2(this decimal number)
            => Math.Round(number, 2, MidpointRounding.AwayFromZero);
        
        public static decimal Pow(this decimal x, decimal y)
            => (decimal) Math.Pow((double) x, (double) y);
    }
}