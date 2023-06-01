using maneroSub.Models.Schemas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Migrations;
using maneroSub.Models.Interfaces.Products;

namespace maneroSub.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductSchema schema)
        {

            if (ModelState.IsValid)
            {
                //kontrollerar om det finns en produkt
                if (await _productService.AnyAsync(x => x.Name == schema.Name))
                    return Conflict("A product with the same name already exists");

                var product = await _productService.CreateAsync(schema);
                if (product != null)
                    return Created("", product);
            }

            ModelState.AddModelError("error", "some errors in the schema");
            return BadRequest();
        }

        //om den inte hittar något får man "notfound"
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
                return BadRequest();

            var product = await _productService.GetAsync(x => x.Id == id);
            if (product != null)
                return Ok(product);

            return NotFound();
        }

        //Hämtar alla produkter
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            if (products.Count() != 0)
                return Ok(products);

            return NotFound();
        }
    }
}