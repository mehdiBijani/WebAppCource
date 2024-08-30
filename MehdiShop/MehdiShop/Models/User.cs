using System.ComponentModel.DataAnnotations;

namespace MehdiShop.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Password { get; set; }
    
    [Required]
    public DateTime RegisterDate { get; set; }
    
    public bool IsAdmin { get; set; }

    #region Navigation Property

    public List<Order> Orders { get; set; }

    #endregion
}