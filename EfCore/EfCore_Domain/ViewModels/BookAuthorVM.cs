using Microsoft.AspNetCore.Mvc.Rendering;
using EfCore_Domain.Models;

namespace EfCore_Domain.ViewModels
{
   public class BookAuthorVM
    {
        public BookAuthor BookAuthor { get; set; }
        public Book Book { get; set; }
        public IEnumerable<BookAuthor> BookAuthors { get; set; }
        public IEnumerable<SelectListItem> AuthorList { get; set; }
    }
}
