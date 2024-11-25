using NewClient.Models;
using NewClient.Models.Dto;

namespace NewClient.Services.Interface;

public interface IDishSizeService
{
    Task<List<DishSize>> GetAllDishSize();
    Task<DishSize> GetDishSizeById(int id);
    
    Task<bool> AddDishSize(DishSizeDto dishSizeDto);

    Task<bool> UpdateDishSize(int id, DishSizeDto dishSizeDto);
    
    Task<bool> DeleteDishSize(int id);
}