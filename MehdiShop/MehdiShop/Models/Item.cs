namespace MehdiShop.Models;

public class Item
{
    public int Id { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }
    
    // Navigation Property
    public Product Product { get; set; }
}