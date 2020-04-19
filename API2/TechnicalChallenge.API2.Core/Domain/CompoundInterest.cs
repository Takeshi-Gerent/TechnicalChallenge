using System;
using TechnicalChallenge.Framework.Extensions;

namespace TechnicalChallenge.API2.Core.Domain
{
    public class CompoundInterest
    {
        public decimal InitialValue { get; set; }
        public decimal InterestRate { get; set; }
        public int Time { get; set; }

        public decimal CalculateCompoundInterest(int? digits)
        {
            var compoundInterest = InitialValue * Convert.ToDecimal(Math.Pow(Convert.ToDouble(1 + InterestRate), Time));
            return !digits.HasValue ? compoundInterest : compoundInterest.Truncate(digits.Value);
        }
    }
}
