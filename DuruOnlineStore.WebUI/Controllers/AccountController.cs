using DuruOnlineStore.WebUI.Models;
using DuruOnlineStore.Common.Models.Identities;
using DuruOnlineStore.Data.Entities.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DuruOnlineStore.WebUI.Controllers
{
	[AllowAnonymous]
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<AppRole> _roleManager;
		private readonly SignInManager<AppUser> _signInManager;

		public AccountController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> RegisterAsync(RegisterUserModel model)
		{
			var newUser = new AppUser
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				UserName = model.Username,
			};

			var result = await _userManager.CreateAsync(newUser, model.Password);

			if (!result.Succeeded)
			{
				//ModelState.AddModelError("username", "Kulanıcı adı boş geçilemez.");
				ModelState.AddModelError("", "'Tüm alanlar zorunludur!'");

				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);
				}

			}
			else
			{
				var adminRole = await _roleManager.FindByNameAsync("Admin");
				if (adminRole != null)
				{
					IdentityResult roleresult = await _userManager.AddToRoleAsync(newUser, adminRole.Name);
				}
				return RedirectToAction("Login");
			}
			return View(model);
		}

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginUserModel model)
		{

			var user = await _userManager.FindByNameAsync(model.Username);
			if (user == null)
			{
				ModelState.AddModelError("", "Kullanıcı adı ve/veya şifre yanlış");
				return View(model);
			}
			var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
			if (!result.Succeeded)
			{
				ModelState.AddModelError("", "Kullanıcı adı ve/veya şifre yanlış");
				return View(model);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}

		public async Task Logout() => await _signInManager.SignOutAsync();

		[HttpGet]
		public IActionResult ForgotPassword()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{

				var user = await _userManager.FindByEmailAsync(model.Email);
				if (user != null)
				{
					var token = await _userManager.GeneratePasswordResetTokenAsync(user);
					var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, token = token }, protocol: HttpContext.Request.Scheme);

					//await _emailSender.SendEmailAsync(user.Email, "Şifre Sıfırlama",
					//$"Lütfen şifrenizi sıfırlamak için aşağıdaki bağlantıya tıklayın: {callbackUrl}");
				}

				ViewBag.Message = "Şifre sıfırlama bağlantısı e-posta adresinize gönderilmiştir.";
				TempData["LoginMessage"] = "Lütfen şifre yenileme işlemini tamamlandıktan sonra giriş yapın.";

				return View();
			}

			return View(model);
		}
	}
}
