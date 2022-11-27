using BankApp.Models;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace BankApp.Tests
{
    [TestFixture]
    public class RegisterViewModel_Validation
    {
        RegisterViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            viewModel = new RegisterViewModel();

            /* Fill all params with values that should be valid. */

            viewModel.FirstName = "Joe";
            viewModel.LastName = "Bloggs";
            viewModel.Address1 = "123 St.";
            viewModel.City = "Citown";
            viewModel.County = "Cork";
            viewModel.Eircode = "A12 B34D";
            viewModel.PhoneNumber = "086 123 1234";
            viewModel.Email = "joe.bloggs@mail.ie";
        }

        /* First Name */

        //Ensure that the default model all other tests are based on validates correctly.
        [Test]
        public void RegisterViewModel_DefaultTestModel_Validates()
        {
            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(0, result.Count);
        }

        //First name, no input.
        [Test]
        public void RegisterViewModel_NoFirstName_Invalidates()
        {
            viewModel.FirstName = "";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }

        //First name, invalid characters.
        [Test]
        public void RegisterViewModel_InvalidCharactersInFirstName_Invalidates()
        {
            viewModel.FirstName = "Joe!";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }

        //First name, too long.
        [Test]
        public void RegisterViewModel_LongFirstName_Invalidates()
        {
            viewModel.FirstName = "SuperDuperLongFirstNameThatNoParentShouldGiveTheirChild";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }

        /* Last Name */

        //Last name, no input.
        [Test]
        public void RegisterViewModel_NoLastName_Invalidates()
        {
            viewModel.LastName = "";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }

        //Last name, invalid characters.
        [Test]
        public void RegisterViewModel_InvalidCharactersInLastName_Invalidates()
        {
            viewModel.LastName = "Bloggs!";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }

        //Last name, too long.
        [Test]
        public void RegisterViewModel_LongLastName_Invalidates()
        {
            viewModel.LastName = "ReallyLongLastNameYouShouldAvoidTakingDuringMarriage";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }

    }
}
