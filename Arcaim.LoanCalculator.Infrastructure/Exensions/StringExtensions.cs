namespace Arcaim.LoanCalculator.Infrastructure.Exensions
{
    public static class StringExtensions
    {
        public static string Stringify(this decimal number)
            => string.Format("{0:0.00}", (double)(number).RoundTo2()).Replace(',', '.');
    }
}