using System.ComponentModel.DataAnnotations;

namespace TestApplication.Models
{
    public class UniqueNameAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value==null)
            {
                return new ValidationResult("Name Is Required");
            }
            var CourseName = value.ToString();
            ApplicationDbContext context = new ApplicationDbContext();
            var courseDB = context.Courses.FirstOrDefault(x=>x.name==CourseName);
            if (courseDB != null)
            {
                return new ValidationResult("Course Name is Exist");
            }

            return ValidationResult.Success; 

        }
    }
}
