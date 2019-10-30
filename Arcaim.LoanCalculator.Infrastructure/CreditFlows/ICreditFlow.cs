using System.Threading.Tasks;
using Arcaim.LoanCalculator.Core.Repositories;

namespace Arcaim.LoanCalculator.Infrastructure.CreditFlows
{
    public interface ICreditFlow
    {
        Task Calculate(ICreditRepository repository);
    }
}