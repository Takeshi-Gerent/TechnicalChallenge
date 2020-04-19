using System.Threading.Tasks;
using TechnicalChallenge.Framework.Service;

namespace TechnicalChallenge.API2.Core.Services
{
    public interface ICalculaJurosService : IServiceBase
    {
        Task<decimal> CalculateCompoundInterest(decimal initialValue, int time, decimal interestRate);
    }
}
