using Newtonsoft.Json;
using NewClient.Models;
using NewClient.Services.Interface;

namespace NewClient.Services
{
    public class IngridientService : IIngridientService
    {
        private readonly string _baseUrl = "http://localhost:5224";
        
        public async Task<IEnumerable<Ingridient>> GetAllAsync()
        {
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Ingridient/GetAllIngridient";
                var apiResponse = await client.GetAsync(url);

                if (apiResponse.IsSuccessStatusCode)
                {
                    var response = await apiResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Ingridient>>(response) ?? new List<Ingridient>();
                }

                Console.Error.WriteLine($"Failed to fetch ingredients. Status Code: {apiResponse.StatusCode}");
                return new List<Ingridient>();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in GetAllIngridient: {ex.Message}");
                return new List<Ingridient>();
            }
        }
        
        public async Task<Ingridient?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Ingridient/GetIngridientById?id={id}";
                var apiResponse = await client.GetAsync(url);

                if (apiResponse.IsSuccessStatusCode)
                {
                    var response = await apiResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Ingridient>(response);
                }

                Console.Error.WriteLine($"Failed to fetch ingredient with ID {id}. Status Code: {apiResponse.StatusCode}");
                return null;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in GetIngridientById: {ex.Message}");
                return null;
            }
        }
        
        public async Task<IEnumerable<Ingridient>> FindByNameAsync(string name)
        {
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Ingridient/GetAllIngridientByName?name={Uri.EscapeDataString(name)}";
                var apiResponse = await client.GetAsync(url);

                if (apiResponse.IsSuccessStatusCode)
                {
                    var response = await apiResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Ingridient>>(response) ?? new List<Ingridient>();
                }

                Console.Error.WriteLine($"Failed to fetch ingredients by name {name}. Status Code: {apiResponse.StatusCode}");
                return new List<Ingridient>();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in FindIngridientByName: {ex.Message}");
                return new List<Ingridient>();
            }
        }

        public async Task<bool> AddIngridient(Ingridient ingridient)
        {
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Ingridient/AddIngridient?name={ingridient.Name}&image={ingridient.Image}";
                var content = new StringContent(JsonConvert.SerializeObject(ingridient), System.Text.Encoding.UTF8, "application/json");

                var apiResponse = await client.PostAsync(url, content);

                if (apiResponse.IsSuccessStatusCode)
                {
                    return true;
                }

                var errorMessage = await apiResponse.Content.ReadAsStringAsync();
                Console.Error.WriteLine($"Failed to add ingredient. Status Code: {apiResponse.StatusCode}, Error: {errorMessage}");
                return false;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in AddIngridient: {ex.Message}");
                return false;
            }
        }
        
        public async Task<bool> UpdateIngridient(Ingridient ingridient)
        {
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Ingridient/UpdateIngridient?name={ingridient.Name}&id={ingridient.Id}&image={ingridient.Image}";
                var content = new StringContent(JsonConvert.SerializeObject(ingridient), System.Text.Encoding.UTF8, "application/json");

                var apiResponse = await client.PutAsync(url, content);

                if (apiResponse.IsSuccessStatusCode)
                {
                    return true;
                }

                Console.Error.WriteLine($"Failed to update ingredient. Status Code: {apiResponse.StatusCode}");
                return false;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in UpdateIngridient: {ex.Message}");
                return false;
            }
        }
        
        public async Task<bool> DeleteAsync(Ingridient ingridient)
        {
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Ingridient/DeleteIngridient?id={ingridient.Id}";
                var apiResponse = await client.DeleteAsync(url);

                if (apiResponse.IsSuccessStatusCode)
                {
                    return true;
                }

                Console.Error.WriteLine($"Failed to delete ingredient. Status Code: {apiResponse.StatusCode}");
                return false;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in DeleteIngridient: {ex.Message}");
                return false;
            }
        }
        
        public async Task<List<DishIngridient>> GetDishIngridientByIdAsync(int id)
        {
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Ingridient/GetDishAndIngridient?id={id}";
                var apiResponse = await client.GetAsync(url);

                if (apiResponse.IsSuccessStatusCode)
                {
                    var response = await apiResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<DishIngridient>>(response) ?? new List<DishIngridient>();
                }

                Console.Error.WriteLine($"Failed to fetch ingredients. Status Code: {apiResponse.StatusCode}");
                return new List<DishIngridient>();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in GetAllIngridient: {ex.Message}");
                return new List<DishIngridient>();
            }
        }
    }
}
