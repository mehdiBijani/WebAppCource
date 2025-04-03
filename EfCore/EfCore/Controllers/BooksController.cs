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
            var books = _db.Books
                .Include(b=>b.Category)
                .Include(b=>b.Publisher)
                .Include(b=>b.BookDetail)
                .Include(b=>b.BookAuthors).ThenInclude(x => x.Author)
                .ToList();
            
            // پیشنهاد نمی شود
            // foreach (var book in books)
            // {
            //     _db.Entry(book).Collection(x=>x.BookAuthors).Load();
            //
            //     foreach (var item in book.BookAuthors)
            //     {
            //         _db.Entry(item).Reference(x => x.Author).Load();
            //     }
            // }
            
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
        
        public IActionResult ManageAuthors(int id)
        {
            BookAuthorVM bookAuthor = new BookAuthorVM()
            {
                BookAuthors = _db.BookAuthors.Include(u=>u.Author)
                    .Include(u=>u.Book)
                    .Where(b=>b.Book_id_fk==id).ToList(),
                BookAuthor = new BookAuthor()
                {
                    Book_id_fk = id
                },
                Book = _db.Books.Find(id)

            };
            List<int> listOfAuthors = bookAuthor.BookAuthors.Select(u => u.Author_id_fk).ToList();
            var tempList = _db.Authors.Where(a=> !listOfAuthors.Contains(a.Id)).ToList();
            bookAuthor.AuthorList = tempList.Select(i => new SelectListItem()
            {
                Value = i.Id.ToString(),
                Text = i.FullName
            });

            return View(bookAuthor);
        }

        [HttpPost]
        public IActionResult ManageAuthors(BookAuthorVM bookAuthorVm)
        {
            if (bookAuthorVm.BookAuthor.Book_id_fk != 0 && bookAuthorVm.BookAuthor.Author_id_fk != 0)
            {
                _db.BookAuthors.Add(bookAuthorVm.BookAuthor);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(ManageAuthors), new {@id = bookAuthorVm.BookAuthor.Book_id_fk});
        }

        public IActionResult RemoveAuthor(int authorId, BookAuthorVM bookAuthorVm)
        {
            int bookId = bookAuthorVm.Book.Id;
            var ba = _db.BookAuthors.FirstOrDefault(b => b.Author_id_fk == authorId && b.Book_id_fk == bookId);
            _db.BookAuthors.Remove(ba);
            _db.SaveChanges();
            return RedirectToAction(nameof(ManageAuthors), new {@id = bookId });
        }
    }
}