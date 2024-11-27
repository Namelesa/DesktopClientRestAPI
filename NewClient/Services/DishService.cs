using Newtonsoft.Json;
using NewClient.Models;
using NewClient.Models.Dto;
using NewClient.Services.Interface;

namespace NewClient.Services
{
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
        
        public async Task<bool> AddDish(DishDto dishDto)
        {
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Dish/AddDish";
                var content = new StringContent(JsonConvert.SerializeObject(dishDto), System.Text.Encoding.UTF8, "application/json");

                var apiResponse = await client.PostAsync(url, content);

                if (apiResponse.IsSuccessStatusCode)
                {
                    return true;
                }

                var errorMessage = await apiResponse.Content.ReadAsStringAsync();
                Console.Error.WriteLine($"Failed to add dish. Status Code: {apiResponse.StatusCode}, Error: {errorMessage}");
                return false;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in AddDish: {ex.Message}");
                return false;
            }
        }
        
        public async Task<bool> UpdateDish(int id, DishDto dishDto)
        {
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Dish/UpdateDish?id={id}";
                var content = new StringContent(JsonConvert.SerializeObject(dishDto), System.Text.Encoding.UTF8, "application/json");

                var apiResponse = await client.PutAsync(url, content);

                if (apiResponse.IsSuccessStatusCode)
                {
                    return true;
                }

                Console.Error.WriteLine($"Failed to update dish. Status Code: {apiResponse.StatusCode}");
                return false;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in UpdateDish: {ex.Message}");
                return false;
            }
        }
        
        public async Task<bool> DeleteDish(int id)
        {
            Console.Error.WriteLine("Enter in method");
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Dish/DeleteDish?id={id}";
                var apiResponse = await client.DeleteAsync(url);

                if (apiResponse.IsSuccessStatusCode)
                {
                    return true;
                }

                Console.Error.WriteLine($"Failed to delete dish. Status Code: {apiResponse.StatusCode}");
                return false;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in DeleteDish: {ex.Message}");
                return false;
            }
        }
    }
}
