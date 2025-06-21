
using Marten.Schema;

namespace Basket.Api.Models;

public class ShoppingCart
{
    // [Identity]
    public string UserName { get; set; } = default;
    public List<ShoppingCartItem> Items { get; set; } = new();
    public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
    // public ShoppingCart(string userName, List<ShoppingCartItem> items)
    public ShoppingCart(string userName)
    {
        UserName = userName;
        // Items = items;
    }
    //Required for mapping
    public ShoppingCart()
    {
    }
}
