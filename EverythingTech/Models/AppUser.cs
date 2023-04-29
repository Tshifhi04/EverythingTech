using EverythingTech.Data.Enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EverythingTech.Models
{
    public class AppUser:IdentityUser
    {
        //[Key]
        //public string Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public string? Image { get; set; }

      
      

       public ICollection<Projects> projects { get; set; }

    }
}
