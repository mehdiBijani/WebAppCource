using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Asp.NetCore.Models;

namespace Asp.NetCore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    private static UserModel _user = new UserModel
    {
        FullName = "Mehdi Bijani",
        UserName = "Hachal7",
        Password = 123
    };

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View(_user);
    }
    [HttpPost]
    public IActionResult Privacy(UserModel user)
    {
        if (ModelState.IsValid)
        {
            _user.FullName = user.FullName;
            _user.UserName = user.UserName;
            _user.Password = user.Password;
        }
        else
            return View(user);

        return RedirectToAction("Privacy");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}