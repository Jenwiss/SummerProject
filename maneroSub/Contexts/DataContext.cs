using maneroSub.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace maneroSub.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}

//Behöver registreras i program delen