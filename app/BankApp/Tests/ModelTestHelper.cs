using System.ComponentModel.DataAnnotations;

namespace BankApp.Tests
{
    public class ModelTestHelper
    {
        public static IList<ValidationResult> Validate(object model)
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, results, true);
            if (model is IValidatableObject)
            {
                (model as IValidatableObject).Validate(validationContext);
            } 

            //Add validation errors to standard output
            if(results.Count > 0)
            {
                foreach(var result in results)
                {
                    Console.WriteLine(result);
                }
            }

            return results;
        }
    }
}
