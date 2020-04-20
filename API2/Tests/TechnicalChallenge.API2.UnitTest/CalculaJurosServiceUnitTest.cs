using System;
using System.Collections.Generic;
using TechnicalChallenge.API2.Service;
using Xunit;

namespace TechnicalChallenge.API2.UnitTest
{
    public class CalculaJurosServiceUnitTest
    {
        public static IEnumerable<object[]> GetParametersFor_CalculoCorreto()
        {
            yield return new object[] { 100M, 5, 105.10M, 0.01M };
            yield return new object[] { 100M, 2, 104.04M, 0.02M };
        }

        private readonly CalculaJurosService _service;
        public CalculaJurosServiceUnitTest()
        {
            _service = new CalculaJurosService();
        }

        [Theory(DisplayName = "CalculateCompoundInterest_CalculoCorreto")]
        [MemberData(nameof(GetParametersFor_CalculoCorreto))]
        public async void CalculateCompoundInterest_CalculoCorreto(decimal initialValue, int time, decimal expectedResult, decimal interestRate)
        {
            var result = await _service.CalculateCompoundInterest(initialValue, time, interestRate);
            Assert.Equal(expectedResult, result);
        }

        [Fact(DisplayName = "CalculateCompoundInterest_CalculoIncorreto")]
        public async void CalculateCompoundInterest_CalculoIncorreto()
        {
            var initialValue = 100M;
            var time = 2;
            var expectedResult = 102.02M;
            var interestRate = 0.01M;

            var result = await _service.CalculateCompoundInterest(initialValue, time, interestRate);
            Assert.NotEqual(expectedResult, result);
        }
    }
}
