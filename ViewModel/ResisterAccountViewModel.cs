using System.ComponentModel.DataAnnotations;

namespace First_MVC.ViewModel
{
    public class ResisterAccountViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required , DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password),Compare("Password",ErrorMessage ="Password and Confirm Is Not Matched")]
        public string ConfirmPassowrd { get; set; }
    }
}
