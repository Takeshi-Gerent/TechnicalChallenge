using System.Threading.Tasks;
using TechnicalChallenge.Framework.Service;

namespace TechnicalChallenge.API2.Core.Services
{
    public interface IShowMeTheCodeService : IServiceBase
    {
        Task<string> GetGitUrl();
    }
}
