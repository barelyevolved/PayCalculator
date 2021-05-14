using PayCalculation;

namespace PayCalculatorTests
{
    internal class PayCalculatorBuilder
    {
        private readonly LegislationData _legislationData = new LegislationData();

        public PayCalculatorBuilder()
        {
            _legislationData.TaxRate = 0M;
            _legislationData.FreePayAllowance = 0M;
        }

        internal PayCalculatorBuilder WithTaxRate(decimal taxRate)
        {
            _legislationData.TaxRate = taxRate;
            return this;
        }

        internal PayCalculatorBuilder WithTaxFreeAllowance(decimal freePayAllowance)
        {
            _legislationData.FreePayAllowance = freePayAllowance;
            return this;
        }

        internal PayCalculator Build()
        {
            return new PayCalculator(_legislationData);
        }
    }
}
