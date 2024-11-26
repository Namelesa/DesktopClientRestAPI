using NewClient.Models;
using NewClient.Models.Dto;

namespace NewClient.Services.Interface;

public interface IDishService
{
    Task<List<Dish>> GetAllDish();
    Task<Dish> GetDishById(int id);
    Task<bool> AddDish(DishDto dishDto);
    Task<bool> UpdateDish(int id, DishDto dishDto);
    Task<bool> DeleteDish(int id);
}