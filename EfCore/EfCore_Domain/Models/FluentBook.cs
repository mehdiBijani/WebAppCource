using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore_Domain.Models;

public class FluentBook
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string? ISBN { get; set; }

    public double Price { get; set; }

    public string PriceRange { get; set; }

    public int Category_id_fk { get; set; }
    public FluentCategory Category { get; set; }
    
    public int? BookDetail_id_fk { get; set; }
    public FluentBookDetail BookDetail { get; set; }
    
    public int Publisher_id_fk { get; set; }
    public FluentPublisher Publisher { get; set; }
    
    //Navigations
    public ICollection<FluentBookAuthor> BookAuthors { get; set; }
}