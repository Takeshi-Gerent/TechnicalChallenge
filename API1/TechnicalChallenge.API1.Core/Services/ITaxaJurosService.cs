using System.Threading.Tasks;
using TechnicalChallenge.Framework.Service;

namespace TechnicalChallenge.API1.Core.Services
{
    public interface ITaxaJurosService : IServiceBase
    {
        Task<decimal> GetInterestRate();
    }
}
