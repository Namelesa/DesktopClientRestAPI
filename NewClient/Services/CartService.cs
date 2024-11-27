using NewClient.Models;
using Newtonsoft.Json;

namespace NewClient.Services;

public class CartService
{
    private const string CartKey = "cart";

    public List<CartItem> GetCart()
    {
        var cartJson = Preferences.Get(CartKey, string.Empty);
        if (string.IsNullOrEmpty(cartJson))
        {
            return new List<CartItem>();
        }
        return JsonConvert.DeserializeObject<List<CartItem>>(cartJson);
    }

    public void SaveCart(List<CartItem> cart)
    {
        var cartJson = JsonConvert.SerializeObject(cart);
        Preferences.Set(CartKey, cartJson);
    }

    public void AddToCart(CartItem newItem)
    {
        var cart = GetCart();
        var existingItem = cart.FirstOrDefault(item => item.ProductId == newItem.ProductId && item.Size == newItem.Size);
        
        if (existingItem != null)
        {
            existingItem.Quantity += 1;
        }
        else
        {
            cart.Add(newItem);
        }
        
        SaveCart(cart);
    }

    public void RemoveFromCart(CartItem itemToRemove)
    {
        var cart = GetCart();
        cart.RemoveAll(item => item.ProductId == itemToRemove.ProductId && item.Size == itemToRemove.Size);
        SaveCart(cart);
    }

    public void UpdateQuantity(CartItem item, int quantity)
    {
        var cart = GetCart();
        var existingItem = cart.FirstOrDefault(cartItem => cartItem.ProductId == item.ProductId && cartItem.Size == item.Size);
        
        if (existingItem != null)
        {
            existingItem.Quantity = quantity;
            SaveCart(cart);
        }
    }
}