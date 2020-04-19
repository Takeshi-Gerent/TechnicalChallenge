using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalChallenge.API1.Core.Services;
using TechnicalChallenge.Framework.Factories;
using Unity;

namespace TechnicalChallenge.API1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxaJurosController : Controller
    {
        private readonly IUnityContainer _container;

        public TaxaJurosController(IUnityContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Retorna o juros de 1% ou 0,01
        /// </summary>
        /// <returns>Taxa de juros para cálculo de juros composto</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _container.Resolve<ServiceFactory>().ServiceOf<ITaxaJurosService>().GetInterestRate();
            return Ok(data.ToString("0.00", new CultureInfo("pt-BR")));           

        }
    }
}