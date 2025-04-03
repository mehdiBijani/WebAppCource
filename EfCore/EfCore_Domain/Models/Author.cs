using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore_Domain.Models;

public class Author
{
    // [DatabaseGenerated(DatabaseGeneratedOption.None)] TODO: جهت محاسبه مقدار این مورد که به صورت پیشفرض Identity می باشد
    public int Id { get; set; }

    [Required]
    [MaxLength(300)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(300)]
    public string LastName { get; set; }

    [Required]
    public string BirthDate { get; set; }

    public string Location { get; set; }

    [NotMapped] 
    public string FullName => string.Join(" ", FirstName, LastName);
    
    public ICollection<BookAuthor>? BookAuthors { get; set; }
}