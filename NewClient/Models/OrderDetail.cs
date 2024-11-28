namespace NewClient.Models;

public class OrderDetail
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    
    public Order Order { get; set; }

    public int DishId { get; set; }
    public Dish Dish { get; set; }

    public decimal Price { get; set; }

    public string Size { get; set; }
    
    public int Quantity { get; set; }
}