namespace NewClient.Models;

public class Ingridient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Image { get; set; }
    
    public IList<Dish> Dishes { get; set; }
}