using aspnet_crm.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace aspnet_crm.Controllers
{
    public class LoginController : Controller
    {
		Context c = new Context();

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Index(Admin p)
		{
			var datavalue = c.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
			if (datavalue != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, p.Username)
				};
				var useridentity = new ClaimsIdentity(claims, "Login");
				ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "Category");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> LogOut()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Login");
		}
	}
}
