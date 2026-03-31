using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using System.IO;
using TourDestinationMVCApp.Interfaces;
using TourDestinationMVCApp.Models;
using TourDestinationMVCApp.DTO;

namespace TourDestinationMVCApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
    public AuthController(IAuthService authService) { _authService = authService; }

    [HttpGet]
    public IActionResult Register()
        {
            return View();
        }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(AuthUserDto model, string password)
    {
        if (!ModelState.IsValid) return View(model);

        var (success, error) = await _authService.RegisterAsync(model, password);
        if (!success)
        {
            ModelState.AddModelError("", error);
            return View(model);
        }

        return RedirectToAction(nameof(Login));
    }

    [HttpGet]
    public IActionResult Login(string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string UserName, string password, string returnUrl = null)
    {
        var (success, user, error) = await _authService.ValidateUserAsync(UserName, password);
        if (!success)
        {
            ModelState.AddModelError("", error);
            return View();
        }

       var claims = new List<Claim>
{
    new Claim("UserId", user.Id.ToString()),
    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
    new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
    new Claim(ClaimTypes.Role, user.Role?.ToString() ?? string.Empty)
};
      

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
            new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8) });

        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);

        return RedirectToAction("Index", "Destinations");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }
}
}
