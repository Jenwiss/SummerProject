using maneroSub.Helpers.Services;
using maneroSub.Models.Dtos;
using maneroSub.Models.Entities;
using maneroSub.Models.Interfaces.Products;
using maneroSub.Models.Schemas;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XTest.UnitTest
{
    public class ProductService_Tests
    {
        //Mock hindrar att saker sparas ner i data basen iom att den bara simulerar aktiviteten
        private Mock<IProductRepository> _productRepo;
        private IProductService _productService;

        public ProductService_Tests() //IProductService productService
        {
            _productRepo = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepo.Object);
        }



        [Fact]
        public async Task CreateAsync_Should_Create_New_ProductEntity_and_Return_Product()
        {
            // Arrange
            ProductSchema schema = new ProductSchema{Name = "Product 1"};
            ProductEntity entity = new ProductEntity {Id = 1, Name = "Product 1" };
            // testar om jag får tillbaka en produk av typen produkt
            _productRepo.Setup(x => x.AddAsync(It.IsAny<ProductEntity>())).ReturnsAsync(entity);

            // Act
            //Lägger in ett schema och får tillbaka en entity
            var result = await _productService.CreateAsync(schema);


            // Assert
            Assert.NotNull(result);
            Assert.IsType<Product>(result);

        }

        [Fact]
        public async Task GetAsync_Should_Return_Product()
        {
            // Arrange
            ProductEntity entity = new ProductEntity { Id = 1, Name = "Product 1" };
            // här hämtar vi en produkt med GetAsync och sätter in ett expression som i servicen
            // 
            _productRepo.Setup(x => x.GetAsync(It.IsAny<Expression<Func<ProductEntity, bool>>>())).ReturnsAsync(entity);

            // Act
            //Hämtar ut produkt 1
            var result = await _productService.GetAsync(x => x.Id == 1);


            // Assert
            Assert.NotNull(result);
            // får tillbaka en produkt
            Assert.IsType<Product>(result);
            // förväntar mig id 1 på produkten och vill se vilket ide jag får tillbaka
            Assert.Equal(entity.Id, result.Id);
        }

    }
}
