using BankApp.Models;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace BankApp.Tests
{
    [TestFixture]
    public class DepositViewModel_Validation
    {
        DepositViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            viewModel = new DepositViewModel();

            /* Fill all params with values that should be valid. */

            viewModel.Amount = 100;
        }

        [Test]
        public void DepositViewModel_DefaultTestModel_Validates()
        {
            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void DepositViewModel_InvalidAmount_Invalidates()
        {
            viewModel.Amount = 1000;

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void DepositViewModel_AmountLowEdge_Validates()
        {
            viewModel.Amount = 0.01m;

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void DepositViewModel_AmountHighEdge_Validates()
        {
            viewModel.Amount = 500m;

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(0, result.Count);
        }
    }
}
