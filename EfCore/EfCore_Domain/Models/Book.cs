using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore_Domain.Models;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(300)]
    public string Title { get; set; }

    [Required]
    [MaxLength(50)]
    public string ISBN { get; set; }

    [Required]
    public double Price { get; set; }

    [NotMapped]
    public string PriceRange { get; set; }

    [ForeignKey("Category")]
    public int Category_id_fk { get; set; }
    
    public Category Category { get; set; }

    [ForeignKey("BookDetail")]
    public int BookDetail_id_fk { get; set; }
    
    public BookDetail BookDetail { get; set; }
    
    [ForeignKey("Publisher")]
    public int Publisher_id_fk { get; set; }
    
    public Publisher Publisher { get; set; }
}