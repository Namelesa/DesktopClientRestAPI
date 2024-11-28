public class CartItem
{
    public int DishId { get; set; }
    public string DishName { get; set; }
    public string DishImage { get; set; }
    public string Size { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public decimal TotalPrice => Price * Quantity;
}