using NewClient.Models;
using NewClient.Services.Interface;
using Newtonsoft.Json;
using System.Text;
using NewClient.Models.Dto;

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

    public async Task<bool> AddDishSize(DishSizeDto dishSizeDto)
    {
        using var client = new HttpClient();
        try
        {
            string url = $"{_baseUrl}/api/Dish/AddDishSize";
            var jsonContent = JsonConvert.SerializeObject(dishSizeDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var apiResponse = await client.PostAsync(url, content);

            if (apiResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Dish size added successfully");
                return true;
            }

            Console.Error.WriteLine($"Failed to add dish size. Status Code: {apiResponse.StatusCode}");
            return false;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in AddDishSize: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> UpdateDishSize(int id, DishSizeDto dishSizeDto)
    {
        using var client = new HttpClient();
        try
        {
            string url = $"{_baseUrl}/api/Dish/UpdateDishSize?id={id}";
            var jsonContent = JsonConvert.SerializeObject(dishSizeDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var apiResponse = await client.PutAsync(url, content);

            if (apiResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Dish size updated successfully");
                return true;
            }

            Console.Error.WriteLine($"Failed to update dish size. Status Code: {apiResponse.StatusCode}");
            return false;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in UpdateDishSize: {ex.Message}");
            return false;
        }
    }
    
    public async Task<bool> DeleteDishSize(int id)
    {
        using var client = new HttpClient();
        try
        {
            string url = $"{_baseUrl}/api/Dish/DeleteDishSize?id={id}";
            var apiResponse = await client.DeleteAsync(url);

            if (apiResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Dish size deleted successfully");
                return true;
            }

            Console.Error.WriteLine($"Failed to delete dish size. Status Code: {apiResponse.StatusCode}");
            return false;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in DeleteDishSize: {ex.Message}");
            return false;
        }
    }
}
