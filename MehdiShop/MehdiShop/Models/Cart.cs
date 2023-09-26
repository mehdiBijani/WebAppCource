namespace MehdiShop.Models;

public class Cart
{
    public Cart()
    {
        CartItems = new List<CartItem>();
    }

    public int OrderId { get; set; }
    public List<CartItem> CartItems { get; set; }

    #region Method

    public void AddItem(CartItem item)
    {
        if (CartItems.Exists(x => x.Item.Id == item.Item.Id))
            CartItems.Find(x => x.Item.Id == item.Item.Id)!.Quantity += 1;
        
        else
            CartItems.Add(item);
    }

    public void RemoveItem(int id)
    {
        var cartItem = CartItems.SingleOrDefault(x => x.Item.Id == id);
        
        if (cartItem?.Quantity > 1)
            cartItem.Quantity -= 1;
        
        else if (cartItem != null) 
            CartItems.Remove(cartItem);
    }

    #endregion
}