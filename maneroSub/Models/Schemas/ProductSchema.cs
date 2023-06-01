using maneroSub.Models.Entities;
using maneroSub.Models.Interfaces.Products;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace maneroSub.Models.Schemas
{
    public class ProductSchema : IProductSchema
    {
        [Required]
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        // ifall det inte finns några värden så blir det inga problem (den försöker itne konvertera autmatiskt)
        public static implicit operator ProductEntity(ProductSchema schema)
        {
            if (schema != null)
                return new ProductEntity
                {
                    Name = schema.Name,
                    Description = schema.Description,
                    Price = schema.Price,
                };
            return null!;
        }
    }
}

/*
 
 
            {
                return new ProductEntity
                {
                    Name = schema.Name,
                    Description = schema.Description,

                    Price = schema.Price,
                };
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
 
 */