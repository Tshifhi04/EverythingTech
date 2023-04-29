using EverythingTech.Data;
using EverythingTech.Models;
using EverythingTech.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EverythingTech.Controllers
{
    public class AccountController : Controller
    {
      
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Login()
        {
            var responce = new LoginVM();
            return View(responce);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
                if (user != null)
                {
                    var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                    if (passwordCheck)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                        if (result.Succeeded)
                        {
                            if (await _userManager.IsInRoleAsync(user, "User"))
                            {
                                return RedirectToAction("Index", "Projects");
                            }
                            //role Admin go to Admin page
                            if (await _userManager.IsInRoleAsync(user, "Admin"))
                            {
                                return RedirectToAction("Index", "User");
                            }
                        }
                        TempData["Error"] = "wrong credentials entered";
                        return View(loginVM);
                    }

                }
            }
            TempData["Error"] = "wrong credentials entered";
            return View(loginVM);

        }
    


        public IActionResult Register()
                {
                    var responce = new RegisterVM();
                    return View(responce);
                }
            [HttpPost]
            public async Task<IActionResult> Register(RegisterVM registerVM)
            {
                if (!ModelState.IsValid) return View(registerVM);

                var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
                if (user != null)
                {

                    TempData["Error"] = "this email is already in use";
                    return View(registerVM);
                }

            var newUser = new AppUser()
            {
                UserName = registerVM.EmailAddress,
                        Email = registerVM.EmailAddress,
                EmailConfirmed = true,



            };
                var newUserResponce = await _userManager.CreateAsync(newUser, registerVM.Password);

                if (newUserResponce.Succeeded)
                    await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                return View("login");
            }

        public async Task<IActionResult> Logout()
        {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Index","Home");
                }

    }

}

