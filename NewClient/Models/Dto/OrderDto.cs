namespace NewClient.Models.Dto;

public class OrderDto
{
    public decimal Total { get; set; }
    public List<OrderDetailDto> OrderDetails { get; set; }
}