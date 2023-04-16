using System.ComponentModel.DataAnnotations;

namespace EverythingTech.ViewModel
{
    public class RegisterVM
    {

        [Display(Name = "Email Address")]
        public string UserName { get; set; }
        [Display (Name = "Email Address")]
        [Required(ErrorMessage ="Email Required")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage ="Enter your password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Passwords do not match Please try again")]
        public string ConfirmPassword { get; set; }

    }
}
