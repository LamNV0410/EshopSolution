using Common_API.Request;
using Common_API.Respone;
using Common_API.Respone.Product;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application_Services.IService
{
    public interface IProductService
    {
        Task<ProductsPagingResponse<VM_Product>> GetAllProductPaging(GetAllProductAPI request);

        Task<VM_Product> GetProductById(int id);
    }
}
