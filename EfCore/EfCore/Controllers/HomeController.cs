using System.Diagnostics;
using EfCore_DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using EfCore_Domain.Models;

namespace EfCore.Controllers;

public class HomeController : Controller
{
    private ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var list = _context.Categories;
        return View(list);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Update(int? id)
    {
        var category = new Category();

        if (id == null)
            return View(category);

        category = _context.Categories.SingleOrDefault(x => x.Id == id);

        if (category == null)
            return NotFound();

        return View(category);
    }

    [HttpPost]
    public IActionResult Update(Category category)
    {
        if (category.Id == 0)
            _context.Categories.Add(category);
        else
            _context.Categories.Update(category);

        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }
    
    public IActionResult Details()
    {
        throw new NotImplementedException();
    }

    public IActionResult Delete(int id)
    {
        var category = _context.Categories.SingleOrDefault(x => x.Id == id);
        
        if (category == null)
            return NotFound();

        _context.Categories.Remove(category);

        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }

    public IActionResult Create()
    {
        throw new NotImplementedException();
    }
}