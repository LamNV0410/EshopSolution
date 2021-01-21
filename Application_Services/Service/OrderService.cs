using Application_Services.IService;
using Data.Entities;
using Data.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Services.Service
{
    public class OrderService : IOrderService
    {
        private readonly EshopDBContext _context;
        public OrderService(EshopDBContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrders(Guid userId)
        {
            var orders = await _context.Orders.Where(x => x.UserId == userId).ToListAsync();

            return orders;
        }

        public async Task<Order> GetOrderById(Guid userId, int orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == orderId && x.UserId == userId);

            return order;
        }
    }
}
