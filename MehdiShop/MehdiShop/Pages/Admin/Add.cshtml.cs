using MehdiShop.Data;
using MehdiShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace MehdiShop.Pages.Admin;

public class Add : PageModel
{
    private MehdiShopContext _context;

    public Add(MehdiShopContext context)
    {
        _context = context;
    }

    [BindProperty]
    public UpdateProductViewModel UpdateProductViewModel { get; set; }

    public void OnGet(int id)
    {
        if (id > 0)
        {
            UpdateProductViewModel = _context.Products.Include(x => x.Item)
                .Where(x => x.Id == id)
                .Select(x => new UpdateProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    QuantityInStock = x.Item.QuantityInStock,
                    Price = x.Item.Price,
                }).FirstOrDefault() ?? new UpdateProductViewModel();
        }
        else
            UpdateProductViewModel = new UpdateProductViewModel { Id = 0 };
    }
    
    public IActionResult OnPost()
    {
        Product? product;

        if (!ModelState.IsValid)
            return Page();

        #region Edit

        if (UpdateProductViewModel.Id > 0)
        {
            product = _context.Products.Find(UpdateProductViewModel.Id);

            if (product != null)
            {
                var item = _context.Items.First(x => x.Id == product.ItemId);

                item.Price = UpdateProductViewModel.Price;
                item.QuantityInStock = UpdateProductViewModel.QuantityInStock;
                product.Name = UpdateProductViewModel.Name;
                product.Description = UpdateProductViewModel.Description;

                _context.SaveChanges();
            }
        }

        #endregion

        #region Add

        else
        {
            var item = new Item
            {
                Price = UpdateProductViewModel.Price,
                QuantityInStock = UpdateProductViewModel.QuantityInStock
            };

            _context.Add(item);
            _context.SaveChanges();

            product = new Product
            {
                Name = UpdateProductViewModel.Name,
                Item = item,
                Description = UpdateProductViewModel.Description
            };
            _context.Add(product);
            _context.SaveChanges();
        }

        #endregion

        if (UpdateProductViewModel.Picture?.Length > 0)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot",
                "images",
                product!.Id + Path.GetExtension(UpdateProductViewModel.Picture.FileName));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                UpdateProductViewModel.Picture.CopyTo(stream);
            }
        }

        return Redirect("Index");
    }
}