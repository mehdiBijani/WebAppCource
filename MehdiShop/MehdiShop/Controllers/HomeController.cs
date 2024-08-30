using System.Diagnostics;
using System.Security.Claims;
using MehdiShop.Data;
using Microsoft.AspNetCore.Mvc;
using MehdiShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MehdiShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MehdiShopContext _context;

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
    
    [Authorize]
    public IActionResult AddToCart(int itemId)
    {
        var product = _context.Products.Include(x => x.Item).SingleOrDefault(x => x.ItemId == itemId);

        if (product != null)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var order = _context.Order.FirstOrDefault(x => x.UserId == userId && !x.IsFinally);
            if (order != null)
            {
                var orderDetail = _context.OrderDetail.FirstOrDefault(x =>
                    x.OrderId == order.Id && x.ProductId == product.Id);
                if (orderDetail != null)
                    orderDetail.Count += 1;
                else
                {
                    orderDetail = new OrderDetail
                    {
                        OrderId = order.Id,
                        ProductId = product.Id,
                        Price = product.Item.Price,
                        Count = 1
                    };
                    
                    _context.OrderDetail.Add(orderDetail);
                }
            }
            else
            {
                order = new Order
                {
                    UserId = userId,
                    CreateDate = DateTime.Now,
                    IsFinally = false
                };
                _context.Order.Add(order);
                _context.SaveChanges();
                
                var orderDetail = new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Price = product.Item.Price,
                    Count = 1
                };
                
                _context.OrderDetail.Add(orderDetail);
            }

            _context.SaveChanges();
        }
        return RedirectToAction("ShowCart");
    }

    [Authorize]
    public IActionResult ShowCart()
    {
        int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var model = _context.Order.Where(x => x.UserId == userId && !x.IsFinally)
            .Include(x => x.OrderDetails)
            .ThenInclude(y => y.Product).FirstOrDefault();
        
        return View(model);
    }

    [Authorize]
    public IActionResult RemoveCart(int detailId)
    {
        var orderDetail = _context.OrderDetail.Find(detailId);

        if (orderDetail.Count > 1)
            orderDetail.Count -= 1;
        else
            _context.Remove(orderDetail);

        _context.SaveChanges();
        
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