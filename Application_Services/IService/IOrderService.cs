using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application_Services.IService
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders(Guid userId);
        Task<Order> GetOrderById(Guid userId, int orderId);
    }
}
