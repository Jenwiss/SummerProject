using maneroSub.Models.Dtos;
using maneroSub.Models.Interfaces.Products;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace maneroSub.Models.Entities
{
    public class ProductEntity : IProductEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }

        // ifall det inte finns några värden så blir det inga problem (den försöker itne konvertera autmatiskt)
        public static implicit operator Product(ProductEntity entity)
        {
            if (entity != null)
                return new Product
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    Price = entity.Price,
                };
            return null!;
        }
    }
}

/*

        public static implicit operator Product(ProductEntity entity)
        {
            try
            {
                return new Product
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    Price = entity.Price,
                };
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }
 
 */