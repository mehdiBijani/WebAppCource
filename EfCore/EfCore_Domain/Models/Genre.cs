using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore_Domain.Models;

// [Table("Genre")]
public class Genre
{
    public int Id { get; set; }

    // [Column("GName")]
    public string Name { get; set; }
}