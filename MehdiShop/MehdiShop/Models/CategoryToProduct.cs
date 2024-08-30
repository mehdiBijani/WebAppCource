namespace MehdiShop.Models;

public class CategoryToProduct
{
    public int ProductId { get; set; }
    
    public int CategoryId { get; set; }
    
    #region Navigation Property

    public Product Product { get; set; }
    
    public Category Category { get; set; }

    #endregion
}