using Application_Services.IService;
using Data.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application_Services.Service
{
    public class OrderDetailService : IOrderDetailsService
    {
        private readonly EshopDBContext _context;
        public OrderDetailService(EshopDBContext context)
        {
            _context = context;
        }
        public async Task<Data.Entities.OrderDetail> GetOrderDetailById(int orderId, int productId)
        {
            var orderDetail = await _context.OrderDetails.FirstOrDefaultAsync(x => x.OrderId == orderId && x.ProductId == productId);
            return orderDetail;
        }

        public async Task<List<Data.Entities.OrderDetail>> GetOrderDetails(int order)
        {
            var orderDetails = await _context.OrderDetails.Include(x => x.Product).Include(x => x.Order).ToListAsync();
            return orderDetails;
        }
    }
}
