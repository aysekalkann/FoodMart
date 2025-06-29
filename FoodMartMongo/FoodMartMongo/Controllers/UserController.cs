using FoodMartMongo.Entities;
using FoodMartMongo.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace FoodMartMongo.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Kayıt sayfasını gösterir
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Kayıt formu gönderildiğinde çalışır
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                ModelState.AddModelError("", "Kullanıcı Adı ve Şifre Boş Geçilemez!");
                return View(user);
            }

            // Kullanıcı adı kontrolü
            var existingUser = await _userService.GetUserByUsernameAsync(user.UserName);
            if (existingUser != null)
            {
                ModelState.AddModelError("", "Bu kullanıcı adı zaten kayıtlı.");
                return View(user);
            }

            await _userService.RegisterUserAsync(user);
            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde yapıldı!";
            return RedirectToAction("Login");
        }

        // Giriş sayfasını gösterir
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Giriş formu gönderildiğinde çalışır
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userService.GetUserByUsernameAsync(username);

            if (user == null || !await _userService.CheckPasswordAsync(user, password))
            {
                ModelState.AddModelError("", "Yanlış kullanıcı adı veya şifre!");
                return View();
            }

            // Giriş başarılıysa session'a kullanıcıyı kaydeder
            HttpContext.Session.SetString("UserId", user.UserId);

            return RedirectToAction("CategoryList", "Category");
        }

        // Çıkış işlemi
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "User");
        }
       
    }
}
