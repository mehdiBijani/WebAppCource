using MehdiShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MehdiShop.Controllers;

public class ProductController : Controller
{
    private MehdiShopContext _context;
    
    public ProductController(MehdiShopContext context)
    {
        _context = context;
    }

    [Route("Group/{id}/{name}")]
    public IActionResult ShowProductByGroupId(int id, string name)
    {               
        ViewData["GroupName"] = name;
        
        var products = _context.CategoryToProducts
            .Where(x => x.CategoryId == id)
            .Include(x => x.Product)
            .Select(x => x.Product)
            .ToList();
        
        return View(products);
    }
}