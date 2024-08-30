namespace MehdiShop.Models;

public class Category
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    #region Navigation Property

    public ICollection<CategoryToProduct> CategoryToProducts { get; set; }

    #endregion
}