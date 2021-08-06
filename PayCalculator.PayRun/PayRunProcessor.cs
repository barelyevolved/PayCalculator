using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PayCalculation.Domain.Interfaces;
using PayCalculation.PayRun.Interfaces;

namespace PayCalculation.PayRun
{
    public class PayRunProcessor
    {
        private readonly IPayCalculator _payCalculator;
        private readonly IEmployeePayRunRepository _employeePayRunRepository;

        public PayRunProcessor(IPayCalculator payCalculator, IEmployeePayRunRepository employeePayRunRepository)
        {
            _payCalculator = payCalculator;
            _employeePayRunRepository = employeePayRunRepository;
        }

        public void Process(IEnumerable<IEmployee> employees, IEnumerable<IEmployeePayRun> employeePayRuns)
        {
            if (employees.Any())
            {
                foreach (var employee in employees)
                {
                    var payCalculation = _payCalculator.CalculatePay(employee);

                    employeePayRuns
                        .Single(pr => pr.EmployeeReference == employee.Reference)
                        .AcceptPayCalculation(payCalculation);
                }

                _employeePayRunRepository.SaveChanges(employeePayRuns);
            }
        }
    }
}
