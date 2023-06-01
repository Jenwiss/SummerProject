using maneroSub.Contexts;
using maneroSub.Models.Entities;
using maneroSub.Models.Interfaces.Products;

namespace maneroSub.Helpers.Repositories
{
    public class ProductRepository : Repo<ProductEntity>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }
    }
}
