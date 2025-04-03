using System.ComponentModel.DataAnnotations;

namespace EfCore_Domain.Models;

public class Publisher
{
    public int Id { get; set; }

    [Required]
    [MaxLength(300)]
    public string Name { get; set; }

    [Required]
    [MaxLength(300)]
    public string Location { get; set; }
    
    public ICollection<Book>? Books { get; set; }
}