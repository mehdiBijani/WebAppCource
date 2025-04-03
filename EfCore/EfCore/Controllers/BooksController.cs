using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using EfCore_DataAccess.Data;
using EfCore_Domain.Models;
using EfCore_Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MyEFProject.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _db;

        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var books = _db.Books.ToList();
            for (int i = 0; i < books.Count; i++)
            {
                books[i].Category = _db.Categories.Find(books[i].Category_id_fk);
                books[i].Publisher = _db.Publishers.Find(books[i].Publisher_id_fk);
            }
            return View(books);
        }

        public IActionResult Upsert(int? id)
        {
            BookVM book=new BookVM();
            book.PublisherList = _db.Publishers.Select(p => new SelectListItem()
            {
                Text = p.Name,
                Value = p.Id.ToString()
            });
            
            book.CategoryList = _db.Categories.Select(p => new SelectListItem()
            {
                Text = p.Title,
                Value = p.Id.ToString()
            });

            if (id == null)
            {
               book.Book=new Book();
                return View(book);
            }

            book.Book = _db.Books.Find(id);
            if (book.Book == null)
                return NotFound();

            return View(book);
        }
        
        [HttpPost]
        public IActionResult Upsert(BookVM crBk)
        {
            if(ModelState.IsValid)
            {
                if (crBk.Book.Id == 0)
                {
                    _db.Add(crBk.Book);
                }
                else
                {
                    _db.Update(crBk.Book);
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crBk);
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _db.Books.Where(x => x.Id == id)
                .Include(x => x.Category)
                .Include(x => x.Publisher)
                .Include(x => x.BookDetail).SingleOrDefault();
            
            if (book == null)
            {
                return NotFound();
            }
            
            return View(book);
        }

        public IActionResult Delete(int id)
        {
            var book = _db.Books.Find(id);
            _db.Books.Remove(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}