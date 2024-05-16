using E_commerce.Setting;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.CustomValid
{
    public class CoverAttribute : ValidationAttribute
    {
        private readonly string _Allowextenstion;
        public CoverAttribute(string AllowExtension)
        {
            this._Allowextenstion = AllowExtension;

        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var isAllow = _Allowextenstion.Split(',').Contains(extension, StringComparer.OrdinalIgnoreCase);
                if (!isAllow)
                {
                    return new ValidationResult($"Extension must be{_Allowextenstion}");
                }
            }
            return ValidationResult.Success;



        }
    }
}
