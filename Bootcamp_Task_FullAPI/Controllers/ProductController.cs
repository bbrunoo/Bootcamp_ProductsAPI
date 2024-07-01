using Bootcamp_Task_FullAPI.Entities;
using Bootcamp_Task_FullAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace Bootcamp_Task_FullAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
            
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<ActionResult> PostProduct(Product product)
        {
            var newProduct = await _productRepository.PostProduct(product);
            return Ok(newProduct);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var products = await _productRepository.GetProductByIdAsync(id);
            return Ok(products);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Guid id, Product product)
        {
            if (product == null) return NotFound("Product not found");
            await _productRepository.UpdateProductById(id, product);
            return Ok("Sucessfuly Edited");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null) return NotFound("Product not found");
            await _productRepository.DeleteProductById(product);
            return Ok("Sucessfuly Deleted");
        }
    }
}
