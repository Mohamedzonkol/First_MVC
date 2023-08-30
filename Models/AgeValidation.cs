using System.ComponentModel.DataAnnotations;

namespace First_MVC.Models
{
    public class AgeValidation : ValidationAttribute
    {
        public int info { get; set; } = 5;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int age = int.Parse (value.ToString()); //cast object to int
          //  if (age%5 == 0) {

            if (age % info == 0) { 
                return ValidationResult.Success;   //Valid
            }
            //faild    massage error
            return new ValidationResult("The Age MMust Be Divided By 5");
        }
    }
}
