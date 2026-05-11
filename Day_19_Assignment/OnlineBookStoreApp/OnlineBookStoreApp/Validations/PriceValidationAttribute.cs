using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreApp.Validations
{
    public class PriceValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            decimal price = (decimal)value;

            if (price > 0 && price <= 5000)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Price must be between 1 and 5000.");
        }
    }
}