using Microsoft.EntityFrameworkCore;
using SmartInventory.Domain.Dtos;
using SmartInventory.Domain.Entity;
using SmartInventory.Domain.Enums;
using SmartInventory.Domain.Repository;
using SmartInventory.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Infrastructure.Repository
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly SmartInventoryDbContext _context;
        private readonly ICustomerRepository _customerRepository;
        private readonly IItemRepository _itemRepository;
        public OrderRepository(SmartInventoryDbContext smartInventoryDbContext, ICustomerRepository customerRepository, IItemRepository itemRepository)
        {
            _context = smartInventoryDbContext;
            _customerRepository = customerRepository;
            _itemRepository = itemRepository;
        }

        public async Task<GetOrderDto> AddOrder(AddOrderDto order)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                await _context.Orders.AddAsync(order.OrderDetails);
                await _context.SaveChangesAsync();

                //foreach (var item in order.OrderItemDetails)
                //{
                //    item.OrderId = order.OrderDetails.Id;
                //    await _context.OrderItems.AddAsync(item);
                //}

                foreach (var orderItem in order.OrderItemDetails)
                {
                    Item item = await _itemRepository.GetItemById(orderItem.ItemId);
                    if (item.Count < orderItem.OrderAmount)
                    {
                        //order.OrderItemDetails.Remove(orderItem);       // Remove entire order
                        orderItem.OrderAmount = item.Count;             // Continue with existing quantity
                    }
                }

                await _context.OrderItems.AddRangeAsync(order.OrderItemDetails);
                await _context.SaveChangesAsync();

                await UpdateOrderPrices(order.OrderDetails.Id);

                await transaction.CommitAsync();

                return await GetOrderById(order.OrderDetails.Id);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<GetOrderDto>> GetAllOrders()
        {
            List<Order> orderDetails = await _context.Orders.ToListAsync();
            List<GetOrderDto> orderViewDetails = new List<GetOrderDto>();
            foreach(var order in orderDetails)
            {
                List<OrderItem> orderItems = await _context.OrderItems.Where(item => item.OrderId == order.Id).ToListAsync();
                GetOrderDto orderView = new GetOrderDto
                {
                    OrderDetails = order,
                    OrderItemDetails = orderItems
                };
                orderViewDetails.Add(orderView);
            }
            return orderViewDetails;
        }

        public async Task<GetOrderDto> GetOrderById(int id)
        {
            Order orderDetails = await _context.Orders.AsNoTracking().FirstOrDefaultAsync(order => order.Id == id);
            List<OrderItem> orderItems = await _context.OrderItems.Where(item => item.OrderId == orderDetails.Id).ToListAsync();

            return new GetOrderDto
            {
                OrderDetails = orderDetails,
                OrderItemDetails = orderItems
            };
        }

        public async Task<float> GetTotalIncomeForGivenRange(DateTime startDate, DateTime endDate)
        {
            return await _context.Orders
                .Where(o => o.OrderDateTime >= startDate && o.OrderDateTime < endDate)
                .SumAsync(o => o.DiscountedTotalPrice);
        }

        public async Task<float> GetTotalProfitForGivenRange(DateTime startDate, DateTime endDate)
        {
            return await _context.Orders
                .Where(o => o.OrderDateTime >= startDate && o.OrderDateTime < endDate)
                .SumAsync(o => o.TotalProfit);
        }

        public async Task<OrderItem> UpdateItemPrices(int itemId, Order orderDetails, Customer customer)
        {
            float unitPrice = 0;
            float totalValue = 0;
            float discountedTotalValue = 0;
            float totalRevenue = 0;
            float totalProfit = 0;
            float loyaltyPointsEarned = 0;
            float standardDiscount = 0;
            float loyaltyDiscount = 0;
            float totalDiscount = 0;
            float transportCost = 0;
            float loadingCost = 0;

            OrderItem orderItem = await _context.OrderItems.AsNoTracking().FirstOrDefaultAsync(item => item.Id == itemId);
            if (orderItem == null)
                throw new Exception("Order Item not found");

            Item item = await _itemRepository.GetItemById(orderItem.ItemId);
            if (item == null)
                throw new Exception("Item not found");

            unitPrice = item.UnitPriceSell / item.AmountPerUnit;
            totalValue = unitPrice * orderItem.OrderAmount;
            standardDiscount = totalValue / 100 * item.Discount;

            loyaltyDiscount = totalValue / 100 * customer.LoyaltyDiscount;

            totalDiscount = standardDiscount + loyaltyDiscount;
            discountedTotalValue = totalValue - totalDiscount;

            totalRevenue = item.UnitPriceBuy / item.AmountPerUnit * orderItem.OrderAmount;
            totalProfit = discountedTotalValue - totalRevenue;

            if (item.TransportType == ItemTransportTypes.AllUnits)
            {
                transportCost = item.TransportCost;
            }
            else if (item.TransportType == ItemTransportTypes.SingleUnit)
            {
                transportCost = item.TransportCost * orderItem.OrderAmount;
            }

            if (item.LoadingType == ItemLoadingTypes.AllUnits)
            {
                loadingCost = item.LoadingCost;
            }
            else if (item.LoadingType == ItemLoadingTypes.SingleUnit)
            {
                loadingCost = item.LoadingCost * orderItem.OrderAmount;
            }
            
            await _context.OrderItems.Where(item => item.Id == itemId).ExecuteUpdateAsync(setter => setter
                .SetProperty(i => i.TotalPrice, (float)Math.Round(totalValue, 2))
                .SetProperty(i => i.StandardDiscount, (float)Math.Round(standardDiscount, 2))
                .SetProperty(i => i.LoyaltyDiscount, (float)Math.Round(loyaltyDiscount, 2))
                .SetProperty(i => i.TotalDiscount, (float)Math.Round(totalDiscount, 2))
                .SetProperty(i => i.DiscountedTotalPrice, (float)Math.Round(discountedTotalValue, 2))
                .SetProperty(i => i.TotalRevenue, (float)Math.Round(totalRevenue, 2))
                .SetProperty(i => i.TotalProfit, (float)Math.Round(totalProfit, 2))
                .SetProperty(i => i.TransportCost, (float)Math.Round(transportCost, 2))
                .SetProperty(i => i.LoadingCost, (float)Math.Round(loadingCost, 2))
            );

            await _itemRepository.UpdateItemRemainingCount(item.Id, orderItem.OrderAmount);

            return await _context.OrderItems.AsNoTracking().FirstOrDefaultAsync(item => item.Id == itemId);
        }

        public Task<GetOrderDto> UpdateOrder(UpdateOrderDto order)
        {
            // TODO - Update order details
            // TODO - Update item details
            // TODO - Back calculations
            // TODO - Recalculations

            throw new NotImplementedException();
        }

        public async Task<GetOrderDto> UpdateOrderPrices(int orderId)
        {
            Order orderDetails = await _context.Orders.AsNoTracking().FirstOrDefaultAsync(order => order.Id == orderId);

            if (orderDetails == null)
                throw new Exception("Order not found");

            List<OrderItem> orderItems = await _context.OrderItems.Where(item => item.OrderId == orderId).ToListAsync();

            float totalValue = 0;
            float discountedTotalValue = 0;
            float totalRevenue = 0;
            float totalProfit = 0;
            int numberOfItems = orderItems.Count;
            float loyaltyPointsEarned = 0;
            float standardDiscount = 0;
            float loyaltyDiscount = 0;
            float totalDiscount = 0;
            float transportCost = 0;
            float loadingCost = 0;

            Customer customer = await _customerRepository.GetCustomerById(orderDetails.CustomerId);
            if (customer == null)
                throw new Exception("Customer not found");

            foreach (var item in orderItems)
            {
                OrderItem orderItem = await UpdateItemPrices(item.Id, orderDetails, customer);
                totalValue += orderItem.TotalPrice;
                standardDiscount += orderItem.StandardDiscount;
                loyaltyDiscount += orderItem.LoyaltyDiscount;
                totalDiscount += orderItem.TotalDiscount;
                discountedTotalValue += orderItem.DiscountedTotalPrice;
                totalRevenue += orderItem.TotalRevenue;
                totalProfit += orderItem.TotalProfit;
                transportCost += orderItem.TransportCost;
                loadingCost += orderItem.LoadingCost;
            }

            totalValue += transportCost + loadingCost;

            discountedTotalValue -= orderDetails.LoyaltyPointsRedeemed;
            totalProfit -= orderDetails.LoyaltyPointsRedeemed;

            await _context.Orders.Where(order => order.Id == orderId).ExecuteUpdateAsync(setter => setter
                .SetProperty(o => o.TotalPrice, totalValue)
                .SetProperty(o => o.StandardDiscount, standardDiscount)
                .SetProperty(o => o.LoyaltyDiscount, loyaltyDiscount)
                .SetProperty(o => o.TotalDiscount, totalDiscount)
                .SetProperty(o => o.DiscountedTotalPrice, discountedTotalValue)
                .SetProperty(o => o.TotalRevenue, totalRevenue)
                .SetProperty(o => o.TotalProfit, totalProfit)
                .SetProperty(o => o.NumberOfItems, numberOfItems)
                .SetProperty(o => o.LoyaltyPointsEarned, Math.Round(discountedTotalValue / 100.0, 2))
            );

            await _customerRepository.UpdateLoyaltyPoints(orderDetails.CustomerId, orderDetails.DiscountedTotalPrice, orderDetails.LoyaltyPointsRedeemed);

            return await GetOrderById(orderId);
        }
    }
}
