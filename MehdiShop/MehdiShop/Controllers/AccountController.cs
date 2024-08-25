using MehdiShop.Data.IRepositories;
using MehdiShop.Models;
using MehdiShop.Resources;
using Microsoft.AspNetCore.Mvc;

namespace MehdiShop.Controllers;

public class AccountController: Controller
{
    private IUserRepository _userRepository;

    public AccountController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

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
}