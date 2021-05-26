using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using WebApi.AppSettingsModels;
using WebApi.TaxCalculation;

namespace WebApi.Tests.TaxCalculation
{
    [TestFixture]
    public class FlatValueTaxCalculatorTests
    {
        private FlatValueTaxCalculator _taxCalculator;

        private Mock<IOptions<FlatValueTaxCalculatorOptions>> _mockOptions;

        [SetUp]
        public void SetUp()
        {
            // Mocks
            _mockOptions = new Mock<IOptions<FlatValueTaxCalculatorOptions>>();
            var optionsModel = BuildFlatValueTaxCalculatorOptions();
            _mockOptions.Setup(x => x.Value).Returns(optionsModel);

            _taxCalculator = new FlatValueTaxCalculator(_mockOptions.Object);
        }

        private FlatValueTaxCalculatorOptions BuildFlatValueTaxCalculatorOptions()
        {
            var model = new FlatValueTaxCalculatorOptions()
            {
                DefaultRate = 10000,
                AnnualIncomeLowerLimit = 200000,
                LowerLimitTaxPercentage = 0.05m
            };

            return model;
        }

        [TestCase(200000, 10000)]
        public void Test_Calculate_AnnualIncomeEqualsAnnualIncomeLowerLimit_TaxedAtDefaultRate(decimal annualIncome, decimal expectedTax)
        {
            // arrange
            // act
            var result = _taxCalculator.Calculate(annualIncome);

            // assert
            Assert.AreEqual(expectedTax, result);
        }

        [TestCase(200001, 10000)]
        [TestCase(500000, 10000)]
        [TestCase(3000000, 10000)]
        public void Test_Calculate_AnnualIncomeGreaterThanAnnualIncomeLowerLimit_TaxedAtDefaultRate(decimal annualIncome, decimal expectedTax)
        {
            // arrange
            // act
            var result = _taxCalculator.Calculate(annualIncome);

            // assert
            Assert.AreEqual(expectedTax, result);
        }

        [TestCase(1, 0.05)]
        [TestCase(150000, 7500)]
        [TestCase(199999, 9999.95)]
        public void Test_Calculate_AnnualIncomeLessThanAnnualIncomeLowerLimit_TaxedAtLowerLimitTaxPercentage(decimal annualIncome, decimal expectedTax)
        {
            // arrange
            // act
            var result = _taxCalculator.Calculate(annualIncome);

            // assert
            Assert.AreEqual(expectedTax, result);
        }
    }
}
