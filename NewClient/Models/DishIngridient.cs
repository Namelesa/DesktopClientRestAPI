namespace NewClient.Models;

public class DishIngridient
{
    public int Id { get; set; }
    public int DishId { get; set; }
    public Dish Dish { get; set; }

    public int IngridientId { get; set; }
    public Ingridient Ingridient { get; set; }
}