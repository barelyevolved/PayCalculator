using PayCalculation.Domain.Interfaces;

namespace PayCalculation
{
    public class PayElement : IPayElement
    {
        public string Name { get; set; }

        public decimal PaymentValue { get; set; }
    }
}
