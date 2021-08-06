using System.Linq;
using PayCalculation.Domain.Interfaces;

namespace PayCalculation
{
    public class PayCalculator : IPayCalculator
    {
        private readonly LegislationData _legislationData;

        public PayCalculator(LegislationData legislationData)
        {
            _legislationData = legislationData;
        }

        public IPayCalculateResult CalculatePay(IEmployee employee)
        {
            var payResult = new PayResult();

            payResult.GrossPay = employee.PayElements.Sum(pe => pe.PaymentValue);
            payResult.NetPay = payResult.GrossPay - ((payResult.GrossPay - _legislationData.FreePayAllowance) * _legislationData.TaxRate);

            return payResult;
        }
    }
}
