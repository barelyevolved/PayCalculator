using System.Collections.Generic;
using PayCalculation.Domain.Interfaces;

namespace PayCalculation.PayRun.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<IEmployee> GetEmployees(int[] references);
        void SaveChanges(IEnumerable<IEmployee> employees);
    }
}
