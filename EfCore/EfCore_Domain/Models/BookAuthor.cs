using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore_Domain.Models;

public class BookAuthor
{
    [ForeignKey("Book")]
    public int Book_id_fk { get; set; }

    [ForeignKey("Author")]
    public int Author_id_fk { get; set; }

    public Book Book { get; set; }

    public Author Author { get; set; }
}