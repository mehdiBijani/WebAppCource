using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore_Domain.Models;

public class FluentBookAuthor
{
    public int Id { get; set; }
    
    public int Book_id_fk { get; set; }
    public FluentBook Book { get; set; }

    public int Author_id_fk { get; set; }
    public FluentAuthor Author { get; set; }
}