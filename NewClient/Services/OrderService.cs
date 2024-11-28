using Newtonsoft.Json;
using NewClient.Models;
using NewClient.Services.Interface;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NewClient.Models.Dto;

namespace NewClient.Services
{
    public class OrderService : IOrderService
    {
        private readonly string _baseUrl = "http://localhost:5224";
        
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Order/GetAllOrders";
                var apiResponse = await client.GetAsync(url);

                if (apiResponse.IsSuccessStatusCode)
                {
                    var response = await apiResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Order>>(response) ?? new List<Order>();
                }

                Console.Error.WriteLine($"Failed to fetch orders. Status Code: {apiResponse.StatusCode}");
                return new List<Order>();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in GetAllOrders: {ex.Message}");
                return new List<Order>();
            }
        }
        
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Order/GetOrderById?id={id}";
                var apiResponse = await client.GetAsync(url);

                if (apiResponse.IsSuccessStatusCode)
                {
                    var response = await apiResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Order>(response);
                }

                Console.Error.WriteLine($"Failed to fetch order with ID {id}. Status Code: {apiResponse.StatusCode}");
                return null;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in GetOrderById: {ex.Message}");
                return null;
            }
        }
        
        public async Task<bool> AddOrderAsync(OrderDto orderDto)
        {
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Order/AddOrder";
                var content = new StringContent(JsonConvert.SerializeObject(orderDto), Encoding.UTF8, "application/json");
                var apiResponse = await client.PostAsync(url, content);

                if (apiResponse.IsSuccessStatusCode)
                {
                    return true;
                }

                var errorMessage = await apiResponse.Content.ReadAsStringAsync();
                Console.Error.WriteLine($"Failed to add order. Status Code: {apiResponse.StatusCode}, Error: {errorMessage}");
                return false;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in AddOrder: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AddOrderDetailsAsync(List<OrderDetailDto> orderDetailsDto)
        {
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Order/AddOrderDetails";
                var content = new StringContent(JsonConvert.SerializeObject(orderDetailsDto), Encoding.UTF8, "application/json");
                var apiResponse = await client.PostAsync(url, content);

                if (apiResponse.IsSuccessStatusCode)
                {
                    return true;
                }

                var errorMessage = await apiResponse.Content.ReadAsStringAsync();
                Console.Error.WriteLine($"Failed to add order details. Status Code: {apiResponse.StatusCode}, Error: {errorMessage}");
                return false;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in AddOrderDetails: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> UpdateOrderDetailAsync(int orderDetailId, OrderDetailDto orderDetailDto)
        {
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Order/UpdateOrderDetail?orderDetailId={orderDetailId}&dishId={orderDetailDto.DishId}&quantity={orderDetailDto.Quantity}&size={orderDetailDto.Size}";
                var content = new StringContent(JsonConvert.SerializeObject(orderDetailDto), Encoding.UTF8, "application/json");
                var apiResponse = await client.PutAsync(url, content);

                if (apiResponse.IsSuccessStatusCode)
                {
                    return true;
                }

                var errorMessage = await apiResponse.Content.ReadAsStringAsync();
                Console.Error.WriteLine($"Failed to update order detail. Status Code: {apiResponse.StatusCode}, Error: {errorMessage}");
                return false;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in UpdateOrderDetail: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> DeleteOrderAsync(int id)
        {
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Order/DeleteOrder?id={id}";
                var apiResponse = await client.DeleteAsync(url);

                if (apiResponse.IsSuccessStatusCode)
                {
                    return true;
                }

                var errorMessage = await apiResponse.Content.ReadAsStringAsync();
                Console.Error.WriteLine($"Failed to delete order. Status Code: {apiResponse.StatusCode}, Error: {errorMessage}");
                return false;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in DeleteOrder: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> DeleteOrderDetailAsync(int detailId)
        {
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Order/DeleteOrderDetail?detailId={detailId}";
                var apiResponse = await client.DeleteAsync(url);

                if (apiResponse.IsSuccessStatusCode)
                {
                    return true;
                }

                var errorMessage = await apiResponse.Content.ReadAsStringAsync();
                Console.Error.WriteLine($"Failed to delete order detail. Status Code: {apiResponse.StatusCode}, Error: {errorMessage}");
                return false;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in DeleteOrderDetail: {ex.Message}");
                return false;
            }
        }
        public async Task<int> GetCreatedOrderIdAsync(OrderDto orderDto)
        {
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Order/AddOrder";
                var content = new StringContent(JsonConvert.SerializeObject(orderDto), Encoding.UTF8, "application/json");
        
                var apiResponse = await client.PostAsync(url, content);
        
                if (apiResponse.IsSuccessStatusCode)
                {
                    var responseContent = await apiResponse.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                    return responseObject?.id ?? 0; // Возвращаем id из ответа
                }

                var errorMessage = await apiResponse.Content.ReadAsStringAsync();
                Console.Error.WriteLine($"Failed to add order. Status Code: {apiResponse.StatusCode}, Error: {errorMessage}");
                return 0;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in AddOrder: {ex.Message}");
                return 0;
            }
        }
        public async Task<bool> AddDishToOrderAsync(int orderId, int dishId, int quantity, string size)
        {
            using var client = new HttpClient();
            try
            {
                string url = $"{_baseUrl}/api/Order/AddDishToOrder?orderId={orderId}&dishId={dishId}&quantity={quantity}&size={size}";
                
                var requestBody = new
                {
                    orderId = orderId,
                    dishId = dishId,
                    quantity = quantity,
                    size = size
                };
                
                var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                var apiResponse = await client.PutAsync(url, content);

                if (apiResponse.IsSuccessStatusCode)
                {
                    return true;
                }

                var errorMessage = await apiResponse.Content.ReadAsStringAsync();
                Console.Error.WriteLine($"Failed to add dish to order. Status Code: {apiResponse.StatusCode}, Error: {errorMessage}");
                return false;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in AddDishToOrderAsync: {ex.Message}");
                return false;
            }
        }

    }
}
