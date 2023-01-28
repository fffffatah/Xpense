using System.ComponentModel.DataAnnotations;

namespace Xpense.CustomAttributes
{
    public class ValidateDateRangeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult(ErrorMessage ?? "* Spent At Date is required");

            DateTime spentAt = (DateTime)value;

            if (spentAt <= DateTime.UtcNow)
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage ?? "* Make sure your date is equal or less than today");
        }
    }
}
