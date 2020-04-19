using System.Threading.Tasks;
using TechnicalChallenge.API2.Core.Services;

namespace TechnicalChallenge.API2.Service
{
    public class ShowMeTheCodeService : IShowMeTheCodeService
    {
        public async Task<string> GetGitUrl()
        {
            return await Task.FromResult("https://github.com/Takeshi-Gerent/TechnicalChallenge");
        }
    }
}
