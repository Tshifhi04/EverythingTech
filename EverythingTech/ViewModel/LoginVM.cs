using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EverythingTech.ViewModel
{
    public class LoginVM
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = " Please enter your Email Address")]

        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
