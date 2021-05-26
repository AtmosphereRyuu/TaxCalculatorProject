using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using WebApi.AppSettingsModels;
using WebApi.TaxCalculation;

namespace WebApi.Tests.TaxCalculation
{
    [TestFixture]
    public class FlatRateTaxCalculatorTests
    {
        private FlatRateTaxCalculator _taxCalculator;

        private Mock<IOptions<FlatRateTaxCalculatorOptions>> _mockOptions;

        [SetUp]
        public void SetUp()
        {
            // Mocks
            _mockOptions = new Mock<IOptions<FlatRateTaxCalculatorOptions>>();
            var optionsModel = BuildFlatRateTaxCalculatorOptions();
            _mockOptions.Setup(x => x.Value).Returns(optionsModel);

            _taxCalculator = new FlatRateTaxCalculator(_mockOptions.Object);
        }

        private FlatRateTaxCalculatorOptions BuildFlatRateTaxCalculatorOptions()
        {
            var model = new FlatRateTaxCalculatorOptions()
            {
                DefaultTaxPercentage = 0.175m
            };

            return model;
        }

        [TestCase(1, 0.175)]
        [TestCase(99876, 17478.3)]
        [TestCase(500000, 87500)]
        public void Test_Calculate_TaxedAtDefaultTaxPercentage(decimal annualIncome, decimal expectedTax)
        {
            // arrange
            // act
            var result = _taxCalculator.Calculate(annualIncome);

            // assert
            Assert.AreEqual(expectedTax, result);
        }
    }
}
