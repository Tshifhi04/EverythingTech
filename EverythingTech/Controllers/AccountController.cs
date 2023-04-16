using EverythingTech.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EverythingTech.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            var responce = new LoginVM();
            return View(responce);
        }


        //[HttpPost]
        //public async Task<IActionResult> Login(LoginVM loginVM)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByEmailAsync(loginVM.Email);
        //        if (user != null)
        //        {
        //            var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
        //            if (passwordCheck)
        //            {
        //                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
        //                if (result.Succeeded)
        //                {
        //                    return RedirectToAction("Index", "BookClub");

        //                }
        //                TempData["Error"] = "wrong credentials entered";
        //                return View(loginVM);
        //            }

        //        }
        //    }
        //    TempData["Error"] = "wrong credentials entered";
        //    return View(loginVM);

        //}
        //}
        //}

        public IActionResult Register()
        {
            var responce = new RegisterVM();
            return View(responce);
        }
        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterVM registerVM)
        //{
        //    if (!ModelState.IsValid) return View(registerVM);

        //    var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
        //    if (user != null)
        //    {

        //        TempData["Error"] = "this email is already in use";
        //        return View(registerVM);
        //    }
        //    var newUser = new AppUser()
        //    {
        //        Email = registerVM.EmailAddress,
        //        UserName = registerVM.UserName,
        //    };
        //    var newUserResponce = await _userManager.CreateAsync(newUser, registerVM.Password);

        //    if (newUserResponce.Succeeded)
        //        await _userManager.AddToRoleAsync(newUser, UserRoles.User);
        //    return View("RegisterCompleted");
        //}

        //public async Task<IActionResult> Logout()
        //{ 
        //    //await _signInManager.SignOutAsync();
        //    //return RedirectToAction("Index");
        //}

    }

}

