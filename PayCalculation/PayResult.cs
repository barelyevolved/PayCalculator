using PayCalculation.Domain.Interfaces;

namespace PayCalculation
{
    public class PayResult : IPayCalculateResult
    {
        public decimal GrossPay { get; set; }

        public decimal NetPay { get; set; }
    }
}
