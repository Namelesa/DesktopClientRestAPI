using System.Net;
using Newtonsoft.Json;
using NewClient.Models;
using NewClient.Services.Interface;

namespace NewClient.Services;

public class DishService : IDishService
{
    private readonly string _baseUrl = "http://localhost:5224";
    
    public async Task<List<Dish>> GetAllDish()
    {
        using var client = new HttpClient();
        try
        {
            string url = $"{_baseUrl}/api/Dish/GetAllDish";
            var apiResponse = await client.GetAsync(url);

            if (apiResponse.IsSuccessStatusCode)
            {
                var response = await apiResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Dish>>(response) ?? new List<Dish>();
            }
            
            Console.Error.WriteLine($"Failed to fetch dishes. Status Code: {apiResponse.StatusCode}");
            return new List<Dish>();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in GetAllDish: {ex.Message}");
            return new List<Dish>();
        }
    }
    
    public async Task<Dish> GetDishById(int id)
    {
        using var client = new HttpClient();
        try
        {
            string url = $"{_baseUrl}/api/Dish/GetDishById?id={id}";
            var apiResponse = await client.GetAsync(url);

            if (apiResponse.IsSuccessStatusCode)
            {
                var response = await apiResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Dish>(response);
            }
            
            Console.Error.WriteLine($"Failed to fetch dish with ID {id}. Status Code: {apiResponse.StatusCode}");
            return null;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in GetDishById: {ex.Message}");
            return null;
        }
    }
}
