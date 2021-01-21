using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application_Services.IService
{
    public interface IOrderDetailsService
    {
        Task<List<OrderDetail>> GetOrderDetails(int order);

        Task<OrderDetail> GetOrderDetailById(int id, int productId);
    }
}
