using Microsoft.AspNetCore.Mvc.Rendering;
using EfCore_Domain.Models;

namespace EfCore_Domain.ViewModels
{
   public class BookVM
    {
        public Book Book { get; set; }
        
        public IEnumerable<SelectListItem>? PublisherList { get; set; }
        
        public IEnumerable<SelectListItem>? CategoryList { get; set; }
    }
}
