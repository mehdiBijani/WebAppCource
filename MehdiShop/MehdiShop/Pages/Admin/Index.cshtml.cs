using MehdiShop.Data;
using MehdiShop.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MehdiShop.Pages.Admin;

public class Index : PageModel
{
    #region Context

    private MehdiShopContext _context;

    public Index(MehdiShopContext context)
    {
        _context = context;
    }

    #endregion
    
    #region Properties

    public IEnumerable<Product> Products { get; set; }

    #endregion
    
    public void OnGet()
    {
        Products = _context.Products.Include(x => x.Item);
    }
    
    public void OnPost()
    {
        
    }
}