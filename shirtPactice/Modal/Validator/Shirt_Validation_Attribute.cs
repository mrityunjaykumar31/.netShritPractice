using shirtPactice.Modal;
using System.ComponentModel.DataAnnotations;

namespace shirtPactice.Modal.Validator
{
    public class Shirt_Validation_Attribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var shrit = validationContext.ObjectInstance as Shirt;

            if (shrit != null && !string.IsNullOrEmpty(shrit.gender))
            {
                if (shrit.gender == "male" && shrit.size < 6)
                {
                    return new ValidationResult("Male size should be greater than 8");
                }

            }
            return ValidationResult.Success;
        }
    }
}
