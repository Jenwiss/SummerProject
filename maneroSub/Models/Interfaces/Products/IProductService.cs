using maneroSub.Models.Dtos;
using maneroSub.Models.Entities;
using maneroSub.Models.Schemas;
using System.Linq.Expressions;

namespace maneroSub.Models.Interfaces.Products
{
    public interface IProductService
    {
        Task<bool> AnyAsync(Expression<Func<ProductEntity, bool>> expression);
        Task<Product> CreateAsync(ProductSchema schema);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetAsync(Expression<Func<ProductEntity, bool>> expression);
    }
}