using Microsoft.AspNetCore.Http;
using SimpleMusicStore.Constants;
using System.ComponentModel.DataAnnotations;

namespace SimpleMusicStore.ModelValidations
{
    public class NonEmptyMp3FileAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = (IFormFile)value;

            if (file.Length <= 0 || file.ContentType == CommonConstants.MP3)
                return new ValidationResult(ErrorMessages.INVALID_FILE);
            else
                return ValidationResult.Success;
        }
    }
}
