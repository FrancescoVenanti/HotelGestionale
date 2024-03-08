using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelGestionale.Data;
using HotelGestionale.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace HotelGestionale.Controllers
{
    public class LoginController : Controller
    {
        private readonly HotelGestionaleContext _context;

        public LoginController(HotelGestionaleContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Login
                    .FirstOrDefaultAsync(m => m.Username == login.Username && m.Password == login.Password);
                if (user == null)
                {
                    TempData["Error"] = "Username o password errati";
                    return RedirectToAction("Login");
                }

                var claims = new List<Claim>
                                        {
                                            new Claim(ClaimTypes.Name, user.Username)
                                        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7),
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home");
            }
            return View(login);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        // Rest of the code...
    }

    
}
