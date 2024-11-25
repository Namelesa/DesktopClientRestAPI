using NewClient.Models;

namespace NewClient.Services.Interface;

public interface IDishService
{
    Task<List<Dish>> GetAllDish();
    Task<Dish> GetDishById(int id);
}