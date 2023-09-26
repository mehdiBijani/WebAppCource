namespace MehdiShop.Models;

public class CartItem
{
    public int Id { get; set; }
    public Item Item { get; set; }
    public int Quantity { get; set; }

    #region Method

    public double GetTotalPrice()
    {
        return Item.Price * Quantity;
    }

    #endregion
}