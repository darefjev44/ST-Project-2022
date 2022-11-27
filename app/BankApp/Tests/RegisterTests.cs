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

        /* Address 1 */

        //Address 1, no input.
        [Test]
        public void RegisterViewModel_NoAddress1_Invalidates()
        {
            viewModel.Address1 = "";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }

        /* City */

        //City, no input.
        [Test]
        public void RegisterViewModel_NoCity_Invalidates()
        {
            viewModel.City = "";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }

        /* County */

        //County, no input.
        [Test]
        public void RegisterViewModel_NoCounty_Invalidates()
        {
            viewModel.County = "";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }

        /* Phone Number */
        //No input
        [Test]
        public void RegisterViewModel_NoPhoneNumber_Invalidates()
        {
            viewModel.PhoneNumber = "";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }

        //Irish Number, no spaces.
        [Test]
        public void RegisterViewModel_PhoneNumberNoSpaces_Validates()
        {
            viewModel.PhoneNumber = "0861231234";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(0, result.Count);
        }

        //Irish Number, no spaces.
        [Test]
        public void RegisterViewModel_PhoneNumberSpaces_Validates()
        {
            viewModel.PhoneNumber = "086 123 1234";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(0, result.Count);
        }

        //Irish Number, International Format
        [Test]
        public void RegisterViewModel_PhoneNumberInternational_Validates()
        {
            viewModel.PhoneNumber = "+353 861231234";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(0, result.Count);
        }

        //Invalid Number
        [Test]
        public void RegisterViewModel_InvalidPhoneNumber_Invalidates()
        {
            viewModel.PhoneNumber = "Not a phone number.";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }

        /* Email */
        //Empty Email
        [Test]
        public void RegisterViewModel_NoEmail_Invalidates()
        {
            viewModel.Email = "";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }

        //Invalid Email
        [Test]
        public void RegisterViewModel_InvalidEmail_Invalidates()
        {
            viewModel.Email = "Not an email.";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }

        //Invalid Email - without local-part
        [Test]
        public void RegisterViewModel_InvalidEmailMissingLocalPart_Invalidates()
        {
            viewModel.Email = "@email.com";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }

        //Invalid Email - without @
        [Test]
        public void RegisterViewModel_InvalidEmailMissingAt_Invalidates()
        {
            viewModel.Email = "joebloggsemail.com";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }

        //Invalid Email - without domain
        [Test]
        public void RegisterViewModel_InvalidEmailMissingDomain_Invalidates()
        {
            viewModel.Email = "joebloggs@";

            var result = ModelTestHelper.Validate(viewModel);

            Assert.AreEqual(1, result.Count);
        }
    }
}
