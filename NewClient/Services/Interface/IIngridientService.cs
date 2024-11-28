using NewClient.Models;
using NewClient.Models.Dto;

namespace NewClient.Services.Interface;
public interface IIngridientService
{
    Task<IEnumerable<Ingridient>> GetAllAsync();
    Task<Ingridient?> GetByIdAsync(int id);
    Task<IEnumerable<Ingridient>> FindByNameAsync(string name);
    Task<bool> AddIngridient(Ingridient ingridient);
    Task<bool> UpdateIngridient(Ingridient ingridient);
    Task<bool> DeleteAsync(Ingridient ingridient);
    Task<List<DishIngridient>> GetDishIngridientByIdAsync(int id);
    public Task<bool> AddIngridientToDish(int dishId, string name);
    public Task<bool> RemoveIngridientFromDish(int dishId, int id);
}