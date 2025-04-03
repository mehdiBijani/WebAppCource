namespace EfCore_Domain.Models;

public class Category
{
    public int Id { get; set; }

    public string Title { get; set; }

    public List<FluentBook> Books { get; set; }
}