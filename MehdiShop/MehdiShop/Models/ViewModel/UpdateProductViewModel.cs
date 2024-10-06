namespace MehdiShop.Models;

public class UpdateProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }
    public IFormFile Picture { get; set; }
}