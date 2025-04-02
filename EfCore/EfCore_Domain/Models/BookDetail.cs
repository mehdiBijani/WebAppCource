using System.ComponentModel.DataAnnotations;

namespace EfCore_Domain.Models;

public class BookDetail
{
    public int Id { get; set; }

    [Required]
    public int NumberOfChapter { get; set; }
    
    [Required]
    public int NumberOfPages { get; set; }

    public double Weight { get; set; }
    
    public Book Book { get; set; }
}

