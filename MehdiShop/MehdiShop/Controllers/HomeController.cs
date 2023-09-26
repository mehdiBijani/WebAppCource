using System.Diagnostics;
using MehdiShop.Data;
using Microsoft.AspNetCore.Mvc;
using MehdiShop.Models;
using Microsoft.EntityFrameworkCore;

namespace MehdiShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MehdiShopContext _context;
    private static Cart _cart = new Cart();

    public HomeController(ILogger<HomeController> logger, MehdiShopContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var products = _context.Products;
        return View(products);
    }
    
    public IActionResult Detail(int id)
    {
        #region Requirement

        var product = _context.Products
            .Include(x => x.Item)
            .SingleOrDefault(x => x.Id == id);

        if (product == null)
            return NotFound();

        var categories = _context.Products
            .Where(x => x.Id == id)
            .SelectMany(y => y.CategoryToProducts)
            .Select(z => z.Category).ToList();

        #endregion

        #region Model

        var model = new DetailViewModel()
        {
            Product = product,
            Categories = categories
        };

        #endregion

        return View(model);
    }
    
    public IActionResult AddToCart(int itemId)
    {
        var product = _context.Products.Include(x => x.Item).SingleOrDefault(x => x.ItemId == itemId);

        if (product != null)
        {
            var cartItem = new CartItem
            {
                Item = product.Item,
                Quantity = 1
            };
            _cart.AddItem(cartItem);
        }
        return RedirectToAction("ShowCart");
    }

    public IActionResult ShowCart()
    {
        var model = new CartViewModel
        {
            CartItems = _cart.CartItems,
            OrderTotal = _cart.CartItems.Sum(x => x.GetTotalPrice())
        };
        return View(model);
    }

    public IActionResult RemoveCart(int itemId)
    {
        _cart.RemoveItem(itemId);
        return RedirectToAction("ShowCart");
    }
    
    [Route("ContactUs")]
    public IActionResult ContactUs()
    {
        return View();
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}