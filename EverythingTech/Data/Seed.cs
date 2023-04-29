using EverythingTech.Data.Enum;
using EverythingTech.Models;
using Microsoft.AspNetCore.Identity;

namespace EverythingTech.Data


{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Projects.Any())
                {
                    context.Projects.AddRange(new List<Projects>()
                    {
                        new Projects()
                        {
                           projectName="Vhuhulwi INC ",
                           projectDescription="a software development company web app with multi functionality capabilities",
                           projectCategory=ProjectCategory.NoobScale,
                           DueDate="12/05/2023",
                           GitLink="https://github.com/Tshifhi04/EverythingTech",
                           HelperCredentials="None",

                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            //Address = new Address()
                            //{
                            //    Street="cul de sac street 285",
                            //    City="Thohoyandou",
                            //    Province=Province.Limpopo,
                            //    PostalCode="0950",

                            //}

                        },
                         new Projects()
                        {
                           projectName="Vhuhulwi INC ",
                           projectDescription="a software development company web app with multi functionality capabilities",
                           projectCategory=ProjectCategory.NoobScale,
                           DueDate="12/05/2023",
                           GitLink="https://github.com/Tshifhi04/EverythingTech",
                           HelperCredentials="None",

                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            //Address = new Address()
                            //{
                            //    Street="cul de sac street 285",
                            //    City="Thohoyandou",
                            //    Province=Province.Limpopo,
                            //    PostalCode="0950",

                            //}

                        },
                       new Projects()
                        {
                           projectName="Vhuhulwi INC ",
                           projectDescription="a software development company web app with multi functionality capabilities",
                           projectCategory=ProjectCategory.NoobScale,
                           DueDate="12/05/2023",
                           GitLink="https://github.com/Tshifhi04/EverythingTech",
                           HelperCredentials="None",

                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360"

                        },
                        new Projects()
                        {
                           projectName="Vhuhulwi INC ",
                           projectDescription="a software development company web app with multi functionality capabilities",
                           projectCategory=ProjectCategory.NoobScale,
                           DueDate="12/05/2023",
                           GitLink="https://github.com/Tshifhi04/EverythingTech",
                           HelperCredentials="None",

                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360"

                        }
                    });
                    context.SaveChanges();
                }


            }
        }


        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
               // Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

               // Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "vhuhulwi04@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "number1",
                        Email = adminUserEmail,
                        EmailConfirmed = true,

                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "number1@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "Chifhie04",
                        Email = appUserEmail,
                        EmailConfirmed = true,

                    };
                    await userManager.CreateAsync(newAppUser, "chifhi@gmail.com");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }

}

