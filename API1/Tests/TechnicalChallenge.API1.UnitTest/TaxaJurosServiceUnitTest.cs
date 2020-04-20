using System;
using TechnicalChallenge.API1.Service;
using Xunit;

namespace TechnicalChallenge.API1.UnitTest
{
    public class TaxaJurosServiceUnitTest
    {
        private readonly TaxaJurosService _service;
        public TaxaJurosServiceUnitTest()
        {
            _service = new TaxaJurosService();
        }

        [Fact(DisplayName = "GetInterestRate")]
        public async void GetInterestRate()
        {
            var result = await _service.GetInterestRate();
            Assert.Equal(0.01M, result);
        }
    }
}
