using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayCalculation;

namespace PayCalculatorTests
{
    [TestClass]
    public class FluentBuilderTestExample
    {
        [TestMethod]
        public void CalculatePay_WithMultiplePayElements_SumsGrossOfPayElements()
        {
            // Arrange
            var employee = new Employee();
            employee.PayElements.Add(new PayElement { Name = "Basic pay", PaymentValue = 400 });
            employee.PayElements.Add(new PayElement { Name = "Overtime pay", PaymentValue = 100 });

            var target = new PayCalculatorBuilder()
                .Build();

            // Act
            var actual = target.CalculatePay(employee);

            // Assert
            Assert.AreEqual(500, actual.GrossPay);
        }

        [TestMethod]
        public void CalculatePay_WithHigherTaxRate_CalculatesNet()
        {
            // Arrange
            var employee = new Employee();
            employee.PayElements.Add(new PayElement { Name = "Basic pay", PaymentValue = 400 });

            var target = new PayCalculatorBuilder()
                .WithTaxRate(0.4M)
                .Build();

            // Act
            var actual = target.CalculatePay(employee);

            // Assert
            Assert.AreEqual(240, actual.NetPay);
        }

        [TestMethod]
        public void CalculatePay_WithFreePayAllowance_CalculatesNet()
        {
            // Arrange
            var employee = new Employee();
            employee.PayElements.Add(new PayElement { Name = "Basic pay", PaymentValue = 400 });

            var target = new PayCalculatorBuilder()
                .WithTaxRate(0.4M)
                .WithTaxFreeAllowance(200)
                .Build();

            // Act
            var actual = target.CalculatePay(employee);

            // Assert
            Assert.AreEqual(320, actual.NetPay);
        }
    }
}
