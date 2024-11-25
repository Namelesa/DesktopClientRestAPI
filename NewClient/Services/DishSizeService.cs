using NewClient.Models;
using NewClient.Services.Interface;
using Newtonsoft.Json;

namespace NewClient.Services;

public class DishSizeService : IDishSizeService
{
    private readonly string _baseUrl = "http://localhost:5224";

    public async Task<List<DishSize>> GetAllDishSize()
    {
        using var client = new HttpClient();
        try
        {
            string url = $"{_baseUrl}/api/Dish/GetAllDishSize";
            var apiResponse = await client.GetAsync(url);

            if (apiResponse.IsSuccessStatusCode)
            {
                var response = await apiResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DishSize>>(response) ?? new List<DishSize>();
            }
            
            Console.Error.WriteLine($"Failed to fetch dish sizes. Status Code: {apiResponse.StatusCode}");
            return new List<DishSize>();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in GetAllDishSize: {ex.Message}");
            return new List<DishSize>();
        }
    }

    public async Task<DishSize> GetDishSizeById(int id)
    { 
        using var client = new HttpClient();
        try
        {
            string url = $"{_baseUrl}/api/Dish/GetDishSizeById?id={id}";
            var apiResponse = await client.GetAsync(url);

            if (apiResponse.IsSuccessStatusCode)
            {
                var response = await apiResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DishSize>(response);
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