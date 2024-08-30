using System.Security.Claims;
using MehdiShop.Data.IRepositories;
using MehdiShop.Models;
using MehdiShop.Resources;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace MehdiShop.Controllers;

public class AccountController: Controller
{
    private IUserRepository _userRepository;

    public AccountController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    #region Register

    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (_userRepository.IsExistEmail(model.Email.ToLower()))
        {
            ModelState.AddModelError("Email", string.Format(ClientResource.Validation_DuplicateProperty, ClientResource.Display_Email));
            return View(model);
        }

        var user = new User
        {
            Email = model.Email.ToLower(),
            Password = model.Password,
            RegisterDate = DateTime.Now,
            IsAdmin = false
        };
        
        _userRepository.AddUser(user);
        
        return View("SuccessRegister", model);
    }

    #endregion

    #region Login

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = _userRepository.GetUserForLogin(model.Email.ToLower(), model.Password);

        if (user == null)
        {
            ModelState.AddModelError("Email", "اطلاعات صحیح نیست!");
            return View(model);
        }

        #region Authentication

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Email),
            new(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var principal = new ClaimsPrincipal(identity);

        var properties = new AuthenticationProperties
        {
            IsPersistent = model.RememberMe
        };

        HttpContext.SignInAsync(principal, properties);

        #endregion
        
        return Redirect("/");
    }
    #endregion

    #region Loguot

    public IActionResult Logout()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return Redirect("/Account/Login");
    }

    #endregion
}