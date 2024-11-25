using NewClient.Models;

namespace NewClient.Services.Interface;

public interface IDishSizeService
{
    Task<List<DishSize>> GetAllDishSize();
    Task<DishSize> GetDishSizeById(int id);
}