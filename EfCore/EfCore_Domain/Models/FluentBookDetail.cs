using System.ComponentModel.DataAnnotations;

namespace EfCore_Domain.Models;

public class FluentBookDetail
{
    public int Id { get; set; }

    public int? NumberOfChapter { get; set; }
    
    public int NumberOfPages { get; set; }

    public double Weight { get; set; }

    //Navigations
    public FluentBook Book { get; set; }
}

