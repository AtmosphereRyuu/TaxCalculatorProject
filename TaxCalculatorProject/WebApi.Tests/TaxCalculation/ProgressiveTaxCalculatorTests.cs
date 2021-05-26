using NUnit.Framework;
using WebApi.TaxCalculation;

namespace WebApi.Tests.TaxCalculation
{
    [TestFixture]
    public class TaxCalculationTestTests
    {
        private ProgressiveTaxCalculator _taxCalculator;

        [SetUp]
        public void SetUp()
        {
            _taxCalculator = new ProgressiveTaxCalculator();
        }

        // 10%
        [TestCase(5000, 500)]
        [TestCase(8350, 835)]

        // 15%
        [TestCase(8351, 835.15)]
        [TestCase(15000, 1832.5)]
        [TestCase(33950, 4675)]

        // 25%
        [TestCase(33951, 4675.25)]
        [TestCase(50000, 8687.5)]
        [TestCase(82250, 16750)]

        // 28%
        [TestCase(82251, 16750.28)]
        [TestCase(120000, 27320)]
        [TestCase(171550, 41754)]

        // 33%
        [TestCase(171551, 41754.33)]
        [TestCase(250000, 67642.5)]
        [TestCase(372950, 108216)]

        // 35%
        [TestCase(372951, 108216.35)]
        [TestCase(500000, 152683.5)]
        public void Test_Calculate_ReturnsExpectedTax(decimal annualIncome, decimal expectedTax)
        {
            // arrange
            // act
            var result = _taxCalculator.Calculate(annualIncome);

            // assert
            Assert.AreEqual(expectedTax, result);
        }
    }
}
