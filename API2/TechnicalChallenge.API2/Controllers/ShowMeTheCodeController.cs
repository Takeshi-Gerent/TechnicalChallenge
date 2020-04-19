using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalChallenge.API2.Core.Services;
using TechnicalChallenge.Framework.Factories;
using Unity;

namespace TechnicalChallenge.API2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly IUnityContainer _container;

        public ShowMeTheCodeController(IUnityContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Exibe a url onde se encontra o repositorio no github
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ShowMeTheCode()
        {
            var gitUrl = await _container.Resolve<ServiceFactory>().ServiceOf<IShowMeTheCodeService>().GetGitUrl();
            return Ok(gitUrl);
        }
    }
}