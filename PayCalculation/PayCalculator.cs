using System.Linq;

namespace PayCalculation
{
    public class PayCalculator
    {
        private readonly LegislationData _legislationData;

        public PayCalculator(LegislationData legislationData)
        {
            _legislationData = legislationData;
        }

        public PayResult CalculatePay(Employee employee)
        {
            var payResult = new PayResult();

            payResult.GrossPay = employee.PayElements.Sum(pe => pe.PaymentValue);
            payResult.NetPay = payResult.GrossPay - ((payResult.GrossPay - _legislationData.FreePayAllowance) * _legislationData.TaxRate);

            return payResult;
        }
    }
}
