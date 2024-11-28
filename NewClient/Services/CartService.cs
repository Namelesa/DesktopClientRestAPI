using NewClient.Models;

namespace NewClient.Services;

public class CartService
{
    private static List<CartItem> _cartItems = new();

    public IReadOnlyList<CartItem> GetCartItems() => _cartItems;

    public static void AddToCart(Dish dish, string size, decimal price, int quantity)
    {
        var existingItem = _cartItems.FirstOrDefault(item => item.DishId == dish.Id && item.Size == size);
        
        if (existingItem != null)
        {
            existingItem.Quantity += quantity; 
        }
        else
        {
            _cartItems.Add(new CartItem
            {
                DishId = dish.Id,
                DishName = dish.Name,
                DishImage = dish.Image,
                Size = size,
                Price = price,
                Quantity = quantity
            });
        }
    }

    public void RemoveFromCart(int dishId, string size)
    {
        var item = _cartItems.FirstOrDefault(i => i.DishId == dishId && i.Size == size);
        if (item != null)
        {
            _cartItems.Remove(item);
        }
    }

    public void UpdateQuantity(int dishId, string size, int quantity)
    {
        var item = _cartItems.FirstOrDefault(i => i.DishId == dishId && i.Size == size);
        if (item != null)
        {
            item.Quantity = quantity;
        }
    }

    public void ClearCart()
    {
        _cartItems.Clear();
    }
}