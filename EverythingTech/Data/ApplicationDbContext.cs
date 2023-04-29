using EverythingTech.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EverythingTech.Data
{
    public class ApplicationDbContext:IdentityDbContext<AppUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        
        
            
        }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Projects> Projects { get; set; }

    }
}
