using System;

namespace Basket.Api.Models;

public class ShoppingCart
{
    public string UserName { get; set; } = default;
    List<ShoppingCartItem> Items { get; set; } = new();
    public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
    public ShoppingCart(string userName)
    {
        UserName = userName;
    }
    //Required for mapping
    public ShoppingCart()
    {
    }
}
