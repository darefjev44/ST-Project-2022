using BankApp.Models;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace BankApp.Tests
{
    [TestFixture]
    public class LoginViewModel_Validation
    {
        LoginViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            viewModel = new LoginViewModel();

            /* Fill all params with values that should be valid. */

            viewModel.UserID = "25";
            viewModel.PIN = "123456";
        }

        [Test]
        public void LoginViewModel_DefaultTestModel_Validates()
        {
            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void LoginViewModel_NoUserID_Invalidates()
        {
            viewModel.UserID = "";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void LoginViewModel_NoPIN_Invalidates()
        {
            viewModel.PIN = "";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }
    }
}
