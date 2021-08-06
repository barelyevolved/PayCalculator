using System;
using System.Collections.Generic;
using PayCalculation.Domain.Interfaces;

namespace PayCalculation.PayRun.Interfaces
{
    public interface IEmployeePayRunRepository
    {
        IEnumerable<IEmployeePayRun> GetEmployeePayRuns(int[] employeeReferences, DateTime processDate);
        void SaveChanges(IEnumerable<IEmployeePayRun> employeePayRuns);
    }
}
