using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreApp.Validations
{
    public class IsbnValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var isbn = value as string;

            if (isbn != null && isbn.Length == 13)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("ISBN must be 13 characters.");
        }
    }
}