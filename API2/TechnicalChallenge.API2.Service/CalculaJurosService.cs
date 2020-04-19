using System.Threading.Tasks;
using TechnicalChallenge.API2.Core.Domain;
using TechnicalChallenge.API2.Core.Services;

namespace TechnicalChallenge.API2.Service
{
    public class CalculaJurosService : ICalculaJurosService
    {
        public CalculaJurosService()
        {
        }

        public async Task<decimal> CalculateCompoundInterest(decimal initialValue, int time, decimal interestRate)
        {
            var compoundInterest = new CompoundInterest
            {
                InitialValue = initialValue,
                Time = time,
                InterestRate = interestRate
            };

            return await Task.FromResult(compoundInterest.CalculateCompoundInterest(2));
        }
    }
}
