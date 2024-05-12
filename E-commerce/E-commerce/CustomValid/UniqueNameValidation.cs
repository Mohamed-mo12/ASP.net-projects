using E_commerce.Models;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.CustomValid
{
    public class UniqueNameValidation : ValidationAttribute
    {
        public UniqueNameValidation()
        {
            
        }
        private readonly ApplicationDbContext context; 
        public UniqueNameValidation(ApplicationDbContext context)
        {

            this.context = context;

        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Name is Null"); 
            }
            string name = value.ToString();

            var registername = context.Users.FirstOrDefault(x => x.UserName == name); 
            if (registername != null)
            {
                return new ValidationResult("Name is Exist"); 
            }

            return ValidationResult.Success; 
           
        }

    }
}
