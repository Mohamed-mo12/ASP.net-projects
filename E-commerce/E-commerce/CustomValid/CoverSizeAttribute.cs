using E_commerce.Setting;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.CustomValid
{
    public class CoverSizeAttribute : ValidationAttribute
    {
        private readonly int _MaxSizebymega;
        public CoverSizeAttribute(int MaxSize)
        {
            this._MaxSizebymega = MaxSize; 
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > _MaxSizebymega)
                {
                    return new ValidationResult("Max Size is 1MB");
                }
            }
            return ValidationResult.Success;

        }

    }
}
