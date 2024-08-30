using System.ComponentModel.DataAnnotations;

namespace MehdiShop.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int UserId { get; set; }
    
    public DateTime CreateDate { get; set; }
    
    public bool IsFinally { get; set; }

    #region Navigation Property

    public User User { get; set; }

    public List<OrderDetail> OrderDetails { get; set; }

    #endregion
}