using LATAM_CDS.AppDbContext.Dto;
using LATAM_CDS.AppDbContext.Models;
using LATAM_CDS.Services.Categories;
using LATAM_CDS.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LATAM_CDS.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("get-list-of-products")]
        public async Task<List<ProductDto>> GetListOfProducts()
        {
            return await _productsService.GetListOfProducts();
        }

        [HttpPost("get-product-by-id")]
        public async Task<ProductDto> GetProduct([FromBody] int id)
        {
            return await _productsService.GetProduct(id);
        }

        [HttpPost("add-product")]
        public async Task<ProductDto> CreateNewProduct([FromBody] ProductDto product)
        {
            return await _productsService.CreateNewProduct(product);
        }

        [HttpPut("edit-product")]
        public async Task<ProductDto> EditProduct([FromBody] ProductDto product)
        {
            return await _productsService.EditProduct(product);
        }

        [HttpDelete("delete-product")]
        public async Task RemoveProduct([FromQuery] int id)
        {
            await _productsService.RemoveProduct(id);
        }

    }
}
