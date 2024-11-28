namespace NewClient.Models.Dto;

public class DishDto
{
    public string Name { get; set; }
    public string? Image { get; set; }
    public decimal Price { get; set; }
    public List<string>? DishIngridientsNames { get; set; }
}