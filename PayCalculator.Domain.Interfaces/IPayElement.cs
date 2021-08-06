namespace PayCalculation.Domain.Interfaces
{
    public interface IPayElement
    {
        string Name { get; set; }

        decimal PaymentValue { get; set; }
    }
}
