namespace PayCalculation.Domain.Interfaces
{
    public interface IEmployeePayRun
    {
        int EmployeeReference { get; }
        void AcceptPayCalculation(IPayCalculateResult payCalculateResult);
    }
}
