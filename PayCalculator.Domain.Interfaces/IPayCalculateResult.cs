namespace PayCalculation.Domain.Interfaces
{
    public interface IPayCalculateResult
    {
        decimal GrossPay { get; set; }

        decimal NetPay { get; set; }
    }
}
