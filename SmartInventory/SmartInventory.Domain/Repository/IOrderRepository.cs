using SmartInventory.Domain.Dtos;
using SmartInventory.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Domain.Repository
{
    public interface IOrderRepository
    {
        Task<GetOrderDto> AddOrder(AddOrderDto order);
        Task<GetOrderDto> UpdateOrder(UpdateOrderDto order);
        Task<OrderItem> UpdateItemPrices(int itemId, Order orderDetails, Customer customer);
        Task<GetOrderDto> UpdateOrderPrices(int orderId);

        Task<List<GetOrderDto>> GetAllOrders();
        Task<GetOrderDto> GetOrderById(int id);

        Task<float> GetTotalIncomeForGivenRange(DateTime startDate, DateTime endDate);
        Task<float> GetTotalProfitForGivenRange(DateTime startDate, DateTime endDate);
    }
}
