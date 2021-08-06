namespace PayCalculation.Domain.Interfaces
{
    public interface IPayCalculator
    {
        IPayCalculateResult CalculatePay(IEmployee employee);
    }
}
