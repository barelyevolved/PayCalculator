using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PayCalculation.Domain.Interfaces;
using PayCalculation.PayRun;
using PayCalculation.PayRun.Interfaces;

namespace PayCalculatorTests
{
    [TestClass]
    public class PayRunProcessorTests
    {
        [TestMethod]
        public void PayRun_WithEmployees_CallsSaveChanges()
        {
            // Arrange
            var builder = new PayRunProcessorBuilder();

            var employees = new List<IEmployee>
            {
                new EmployeeBuilder().WithReference(1).Build(),
                new EmployeeBuilder().WithReference(2).Build()
            };

            var employeePayRuns = new List<IEmployeePayRun>
            {
                new EmployeePayRunBuilder().WithReference(1).Build(),
                new EmployeePayRunBuilder().WithReference(2).Build()
            };

            var target = builder
                .WithRepositoryEmployeePayRuns(employeePayRuns)
                .Build();

            // Act
            target.Process(employees, employeePayRuns);

            // Assert
            builder.VerifyEmployeePayRunsWereSaved();
        }

        internal class EmployeeBuilder
        {
            private readonly Mock<IEmployee> _mockEmployee = new Mock<IEmployee>();

            internal EmployeeBuilder WithReference(int reference)
            {
                _mockEmployee.SetupGet(x => x.Reference).Returns(reference);
                return this;
            }

            internal IEmployee Build()
            {
                return _mockEmployee.Object;
            }
        }

        internal class EmployeePayRunBuilder
        {
            private readonly Mock<IEmployeePayRun> _mockEmployeePayRun = new Mock<IEmployeePayRun>();

            internal EmployeePayRunBuilder WithReference(int reference)
            {
                _mockEmployeePayRun.SetupGet(x => x.EmployeeReference).Returns(reference);
                return this;
            }

            internal IEmployeePayRun Build()
            {
                return _mockEmployeePayRun.Object;
            }
        }

        internal class PayRunProcessorBuilder
        {
            private readonly Mock<IPayCalculator> _mockPayCalculator = new Mock<IPayCalculator>();
            private readonly Mock<IEmployeePayRunRepository> _mockEmployeePayRunRepository = new Mock<IEmployeePayRunRepository>();

            internal PayRunProcessorBuilder WithRepositoryEmployeePayRuns(IEnumerable<IEmployeePayRun> employeePayRuns)
            {
                _mockEmployeePayRunRepository.Setup(x => x.GetEmployeePayRuns(It.IsAny<int[]>(), It.IsAny<DateTime>())).Returns(employeePayRuns);
                return this;
            }

            internal void VerifyEmployeePayRunsWereSaved()
            {
                _mockEmployeePayRunRepository.Verify(x => x.SaveChanges(It.IsAny<IEnumerable<IEmployeePayRun>>()), Times.Once);
            }

            internal PayRunProcessor Build()
            {
                return new PayRunProcessor(
                    _mockPayCalculator.Object,
                    _mockEmployeePayRunRepository.Object);
            }
        }
    }
}
