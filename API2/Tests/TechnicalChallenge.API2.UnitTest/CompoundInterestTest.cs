using System;
using TechnicalChallenge.API2.Core.Domain;
using Xunit;

namespace TechnicalChallenge.API2.UnitTest
{
    public class CompoundInterestTest
    {
        [Fact(DisplayName = "CalculateCompoundInterest_Correto")]
        public void CalculateCompoundInterest_Correto()
        {
            var compoundInterest = new CompoundInterest
            {
                InitialValue = 100M,
                InterestRate = 0.01M,
                Time = 5
            };
            var result = compoundInterest.CalculateCompoundInterest(2);

            Assert.Equal(105.1M, result);
        }

        [Fact(DisplayName = "CalculateCompoundInterest_Incorreto")]
        public void CalculateCompoundInterest_Incorreto()
        {
            var compoundInterest = new CompoundInterest
            {
                InitialValue = 100M,
                InterestRate = 0.01M,
                Time = 5
            };
            var result = compoundInterest.CalculateCompoundInterest(2);

            Assert.NotEqual(105.11M, result);
        }

        [Fact(DisplayName = "CalculateCompoundInterest_SemTruncate")]
        public void CalculateCompoundInterest_SemTruncate()
        {
            var compoundInterest = new CompoundInterest
            {
                InitialValue = 100M,
                InterestRate = 0.01M,
                Time = 5
            };
            var result = compoundInterest.CalculateCompoundInterest(null);

            Assert.Equal(105.1010050100M, result);
        }
    }
}
