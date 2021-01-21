using Application_Services.IService;
using Common_API.Request;
using Common_API.Respone;
using Common_API.Respone.Product;
using Data.Entities;
using Data.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Application_Services.Service
{
    public class ProductService : IProductService
    {
        private readonly EshopDBContext _context;
        public ProductService(EshopDBContext context)
        {
            _context = context;
        }
        public async Task<ProductsPagingResponse<VM_Product>> GetAllProductPaging(GetAllProductAPI request)
        {
            ProductsPagingResponse<VM_Product> response = null;

            var query = _context.Products.Include(x => x.ImageProducts).Include(x => x.Category);

            var result = await query.Select(x => new VM_Product()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity,
                Decription = x.Decription,
                CategoryId = x.Category.Id,
                CategoryName = x.Category.Name,
                OriginalPrice = x.OriginalPrice,
                ImageProducts = x.ImageProducts
            }).ToListAsync();

            response = new ProductsPagingResponse<VM_Product>()
            {
                Items = result
            };

            return response;
        }

        public async Task<VM_Product> GetProductById(int id)
        {
            Product productContext = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            VM_Product product =null;
            if (productContext != null)
            {
                product = new VM_Product()
                {
                    Id = productContext.Id,
                    Name = productContext.Name,
                    Price = productContext.Price,
                    Quantity = productContext.Quantity,
                    Decription = productContext.Decription,
                    CategoryId = productContext.Category.Id,
                    CategoryName = productContext.Category.Name,
                    OriginalPrice = productContext.OriginalPrice,
                    ImageProducts = productContext.ImageProducts
                };
            }

            return product;
        }
    }
}
