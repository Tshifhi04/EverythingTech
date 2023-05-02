using EverythingTech.Data;
using EverythingTech.Interfaces;
using EverythingTech.Models;
using EverythingTech.Services;
using EverythingTech.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EverythingTech.Controllers
{
    public class UserController : Controller
    {


        private readonly IUserRepository _userRepository;
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;
        private readonly IPhotoService _photoService;
        private readonly SignInManager<AppUser> _signInManager;



        public UserController(IUserRepository userRepository, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, IPhotoService photoService)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _photoService = photoService;


        }
        [HttpGet("users")]
        public async Task<IActionResult> Index()
        {
           // var isSignedIn = _signInManager.IsSignedIn(User);

            var users = await _userRepository.GetAllUsers();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userViewModel = new UserViewModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    ProfileImageUrl = user.ProfileImageUrl,
                    Surname = user.Surname,
                    Email = user.Email,
                    ProfileBio = user.ProfileBio,



                }; result.Add(userViewModel);
            }
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return RedirectToAction("Index", "Users");
            }

            var userDetailViewModel = new UserDetaiilsViewModel()
            {
                Id = user.Id,

                Email = user.Email,
                Surname = user.Surname,
                Name = user.Name,
                Image = user.ProfileImageUrl ?? "/img/avatar-male-4.jpg",
                ProfileBio = user.ProfileBio,

            };
            return View(userDetailViewModel);

        }



        public async Task<IActionResult> ManageUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return RedirectToAction("Index", "Users");
            }

            var manageUserViewModel = new ManageUserViewModel()
            {
                Id = user.Id,

                Email = user.Email,
                Surname = user.Surname,
                Name = user.Name,
                ProfileImageUrl = user.ProfileImageUrl ?? "/img/avatar-male-4.jpg",
                ProfileBio = user.ProfileBio,

            };
            return View(manageUserViewModel);

        }

        //must make admin be able to manipulate data
        [HttpPost]
        [Authorize]
          public async Task<IActionResult> ManageUser(string id,ManageUserViewModel manageVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View("EditProfile", manageVM);
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return View("Error");
            }

            if (manageVM.Image != null) // only update profile image
            {
                var photoResult = await _photoService.AddPhotoAsync(manageVM.Image);

                if (photoResult.Error != null)
                {
                    ModelState.AddModelError("Image", "Failed to upload image");
                    return View("ManageUser", manageVM);
                }

                if (!string.IsNullOrEmpty(user.ProfileImageUrl))
                {
                    _ = _photoService.DeletePhotoAsync(user.ProfileImageUrl);
                }

                user.ProfileImageUrl = photoResult.Url.ToString();
                manageVM.ProfileImageUrl= user.ProfileImageUrl;

                await _userManager.UpdateAsync(user);
                //  await _context.SaveChangesAsync();

               

                return View(manageVM);
            }

            user.Name = manageVM.Name;
            user.Surname = manageVM.Surname;
            user.Email = manageVM.Email;
            user.ProfileBio = manageVM.ProfileBio;

            await _userManager.UpdateAsync(user);
          

            return RedirectToAction("Index", "User", new { user.Id });
        }
    


    [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return View("Error");
            }

            var editMV = new EditProfileViewModel()
            {
                Name = user.Name,
                Surname = user.Surname ,

                Email = user.Email,
               //ProfileImageUrl= user.Image,
                ProfileImageUrl = user.ProfileImageUrl,
                ProfileBio=user.ProfileBio,
            };
            return View(editMV);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditProfile(EditProfileViewModel editVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View("EditProfile", editVM);
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return View("Error");
            }

            if (editVM.Image != null) // only update profile image
            {
                var photoResult = await _photoService.AddPhotoAsync(editVM.Image);

                if (photoResult.Error != null)
                {
                    ModelState.AddModelError("Image", "Failed to upload image");
                    return View("EditProfile", editVM);
                }

                if (!string.IsNullOrEmpty(user.ProfileImageUrl))
                {
                    _ = _photoService.DeletePhotoAsync(user.ProfileImageUrl);
                }

                user.ProfileImageUrl = photoResult.Url.ToString();
                editVM.ProfileImageUrl = user.ProfileImageUrl;

                await _userManager.UpdateAsync(user);

                return View(editVM);
            }

            user.Name = editVM.Name;
            user.Surname = editVM.Surname;
            user.Email = editVM.Email;
         user.ProfileBio =editVM.ProfileBio;

            await _userManager.UpdateAsync(user);

            return RedirectToAction("Details", "User", new { user.Id });
        }
    }
}
