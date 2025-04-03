using System.ComponentModel.DataAnnotations;

namespace EfCore_Domain.Models;

public class FluentPublisher
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Location { get; set; }

    //Navigations
    public ICollection<FluentBook> Books { get; set; }
}