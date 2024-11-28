using NewClient.Models;
using NewClient.Models.Dto;

namespace NewClient.Services.Interface;

public interface IOrderService
{
    public Task<IEnumerable<Order>> GetAllOrdersAsync();
    public Task<Order?> GetOrderByIdAsync(int id);
    public Task<bool> AddOrderAsync(OrderDto orderDto);
    public Task<bool> AddOrderDetailsAsync(List<OrderDetailDto> orderDetailsDto);
    public Task<bool> UpdateOrderDetailAsync(int orderDetailId, OrderDetailDto orderDetailDto);
    public Task<bool> DeleteOrderAsync(int id);
    public Task<bool> DeleteOrderDetailAsync(int detailId);
    public Task<int> GetCreatedOrderIdAsync(OrderDto orderDto);
    public Task<bool> AddDishToOrderAsync(int orderId, int dishId, int quantity, string size);
}