using System.Threading.Tasks;
using TechnicalChallenge.API1.Core.Services;

namespace TechnicalChallenge.API1.Service
{
    public class TaxaJurosService : ITaxaJurosService
    {
        private const decimal interestRate = 0.01M;

        public TaxaJurosService()
        {
        }

        public async Task<decimal> GetInterestRate()
        {
            return await Task.FromResult(interestRate);
        }
    }
}
