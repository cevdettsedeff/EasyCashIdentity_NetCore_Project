using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    [Authorize]
    public class MyAccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyAccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        { 
            // Sisteme login olan kullanıcın bilgisini getiriyoruz.
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditDto appUserEditDto = new()
            {
                Name = values.Name,
                Surname = values.Surname,
                PhoneNumber = values.PhoneNumber,
                Email = values.Email,
                City = values.City,
                District = values.District,
                ImageUrl = values.ImageUrl
            };
            return View(appUserEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDto appUserEditDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.PhoneNumber = appUserEditDto.PhoneNumber;
            user.Surname = appUserEditDto.Surname;
            user.City = appUserEditDto.City;
            user.District = appUserEditDto.District;
            user.Name = appUserEditDto.Name;
            user.ImageUrl = "test";
            user.Email = appUserEditDto.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}
