using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using rlf.ViewModels;
using Microsoft.EntityFrameworkCore;
using rlf.Data;
using rlf.Data.Models;

namespace TGM.Controllers
{
    public class AccountController(ILogger<AccountController> logger, AppDBContent context) : Controller
    {
		private readonly ILogger<AccountController> _logger = logger;
		private readonly AppDBContent _db = context;

        // GET: Account/Profile
        [Authorize]
        public IActionResult Profile()
        {
            var currentLogin = HttpContext.User.Identity.Name;

            var profile = _db.Users.Where(u => u.Login == currentLogin)
                .Include(u => u.Role)
                .Include(u => u.UserProfile)
                .SingleOrDefault();

            return View(profile);
        }

        // GET: Account/Register
        public IActionResult Register()
		{
			return View();
		}

        // POST: Account/Register
        [HttpPost]
        public IActionResult Register(RegisterModel regUser)
        {
            if (!ModelState.IsValid || regUser.Password != regUser.ConfirmPassword)
            {
                ModelState.AddModelError("isRegFailed", "Пароль некорректный");
                return View(regUser);
            }
            if (_db.Users.Where(u => u.Login == regUser.Login || u.Login == regUser.Email || u.Email == regUser.Login || u.Email == regUser.Email).Any())
            {
                ModelState.AddModelError("isRegFailed", "Логин или почта уже существуют");
                return View(regUser);
            }

            var user = new User
            {
                Login = regUser.Login,
                Email = regUser.Email,
                Password = regUser.Password.ToHash(),
                RoleId = 2
            };

            _db.Users.Add(user);
            _db.SaveChangesAsync().Wait();

            return RedirectToAction(nameof(Login));
        }

        // GET: Account/Login
        public IActionResult Login()
		{
			return View();
		}

		// POST: Account/Login
		[HttpPost]
        public async Task<IActionResult> Login(LoginModel loginUser)
        {
            var userToLogin = await _db.Users
                .Where(u =>
                    u.Login == loginUser.LoginOrEmail ||
                    u.Email == loginUser.LoginOrEmail)
                .Include(u => u.Role)
                .SingleOrDefaultAsync();

            if (userToLogin is null)
            {
                _logger.LogWarning("At {time} Failed login attempt was made with {login}", DateTime.Now.ToString("u"), loginUser.LoginOrEmail);
                ModelState.AddModelError("isLoginFailed", "Неверный логин");
                return View(loginUser);
            }
            if (userToLogin?.Password != loginUser.Password.ToHash())
            {
                _logger.LogWarning("At {time} Failed login attempt was made with {login}", DateTime.Now.ToString("u"), loginUser.LoginOrEmail);
                ModelState.AddModelError("isLoginFailed", "Неверный пароль");
                return View(loginUser);
            }

            // Аутентификация пользователя и добавление идентификатора в куки
            //Authenticate(userToLogin);

            // Перенаправление на страницу списка транзакций с передачей идентификатора пользователя
            return RedirectToAction("List", "Transactions", new { userId = userToLogin.Id });
        }

        private void Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Login),
                new(ClaimTypes.Role, user.Role.Name),
                new(ClaimTypes.NameIdentifier, user.Id.ToString()) // Используем стандартное имя утверждения для идентификатора пользователя
            };

            ClaimsIdentity id = new(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            // Создаем объект ClaimsPrincipal с учетом добавленного идентификатора пользователя
            var principal = new ClaimsPrincipal(id);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();
        }

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            return RedirectToAction(nameof(Login), "Account");
        }
    }
}
