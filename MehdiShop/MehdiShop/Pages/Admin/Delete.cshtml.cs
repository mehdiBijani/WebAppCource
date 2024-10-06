using MehdiShop.Data;
using MehdiShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MehdiShop.Pages.Admin;

public class Delete : PageModel
{
    private MehdiShopContext _context;

    public Delete(MehdiShopContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Product Product { get; set; }

    public void OnGet(int id)
    {
        Product = _context.Products.Find(id)!;
    }

    public IActionResult OnPost()
    {
        var product = _context.Products.Find(Product.Id);
        if (product != null)
        {
            var item = _context.Items.Find(product.ItemId);

            if(item !=null)
                _context.Items.Remove(item);
            _context.Products.Remove(product);
            _context.SaveChanges();
            
            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot",
                "images",
                product!.Id + ".jpg");

            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
        }

        return RedirectToPage("Index");
    }
}