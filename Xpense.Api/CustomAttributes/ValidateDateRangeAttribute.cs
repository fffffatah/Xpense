using System.ComponentModel.DataAnnotations;

namespace Xpense.Api.CustomAttributes;

public class ValidateDateRangeAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime spentAt;
        if (!DateTime.TryParse(value.ToString(), out spentAt))
        {
            return new ValidationResult(ErrorMessage ?? "* Invalid date format");
        }

        if (spentAt <= DateTime.UtcNow)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "* Make sure your date is equal to or less than today");

    }
}