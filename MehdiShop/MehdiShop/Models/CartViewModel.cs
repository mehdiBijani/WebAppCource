namespace MehdiShop.Models;

public class CartViewModel
{
    public CartViewModel()
    {
        CartItems = new List<CartItem>();
    }

    public List<CartItem> CartItems { get; set; }
    public double OrderTotal { get; set; }
}