using System.ComponentModel.DataAnnotations;

namespace First_MVC.ViewModel
{
    public class RoleViewModel
    {
        [Required]
       public string RoleName { get; set; }
    }
}
