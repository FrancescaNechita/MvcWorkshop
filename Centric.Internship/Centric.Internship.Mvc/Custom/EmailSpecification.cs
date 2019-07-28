using System.ComponentModel.DataAnnotations;

namespace Centric.Internship.Mvc.Custom
{
    public class EmailSpecification : ValidationAttribute
    {
        protected override ValidationResult IsValid(object email, ValidationContext validationContext)
        {
            if (email == null)
            {
                return new ValidationResult("Email is required.");
            }

            if (email.ToString().EndsWith("centric.eu") || email.ToString().EndsWith("gmail.com"))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Email address must belong to Centric or Gmail account.");
            }
        }
    }

}