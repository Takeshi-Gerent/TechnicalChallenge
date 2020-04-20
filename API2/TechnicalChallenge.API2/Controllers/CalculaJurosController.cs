using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
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
    public class CalculaJurosController : ControllerBase
    {
        private readonly IUnityContainer _container;

        public CalculaJurosController(IUnityContainer container)
        {
            this._container = container;            
        }

        /// <summary>
        /// Calcula juros compostos
        /// </summary>
        /// <param name="valorinicial">Valor inicial</param>
        /// <param name="meses">Tempo em meses</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> CalculaJuros(decimal valorinicial, int meses)
        {
            var interestRate = await GetInterestRate();
            var result = await _container.Resolve<ServiceFactory>().ServiceOf<ICalculaJurosService>().CalculateCompoundInterest(valorinicial, meses, interestRate);
            return Ok(result.ToString("0.00", new CultureInfo("pt-BR")));
        }

        protected virtual async Task<decimal> GetInterestRate()
        {
            var str = string.Empty;
            var client = _container.Resolve<HttpClient>("api1");
            HttpResponseMessage response = await client.GetAsync("taxajuros");
            if (response.IsSuccessStatusCode)
            {
                str = await response.Content.ReadAsStringAsync();
            }
            return decimal.Parse(str, new CultureInfo("pt-BR"));

        }
    }
}