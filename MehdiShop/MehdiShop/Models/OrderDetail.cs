using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MehdiShop.Models;

public class OrderDetail
{
    [Key]
    public int Id { get; set; }  
    
    [Required]
    public int OrderId { get; set; } 
    
    [Required]
    public int ProductId { get; set; }

    [Required]
    public int Count { get; set; }

    [Required]
    public double Price { get; set; }

    #region Navigation Property

    public Order Order { get; set; }  
    
    [ForeignKey("ProductId")]
    public Product Product { get; set; }

    #endregion
}