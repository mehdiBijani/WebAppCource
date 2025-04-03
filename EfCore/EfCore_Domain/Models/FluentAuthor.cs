using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore_Domain.Models;

public class FluentAuthor
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? BirthDate { get; set; }

    public string? Location { get; set; }

    public string FullName => string.Join(" ", FirstName, LastName);

    //Navigations
    public ICollection<FluentBookAuthor> BookAuthors { get; set; }
}