using Bootcamp_Task_FullAPI.Context;
using Bootcamp_Task_FullAPI.Entities;
using Bootcamp_Task_FullAPI.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp_Task_FullAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AplicationDataContext _context;
        public ProductRepository(AplicationDataContext context)
        {
            _context = context;
        }
        public async Task<Product> PostProduct(Product Product)
        {
            await _context.AddAsync(Product);
            await _context.SaveChangesAsync();
            return Product;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid Id)
        {
            return await _context.Product.FindAsync(Id);
        }
        public async Task UpdateProductById(Guid Id, Product product)
        {
            var products = await _context.Product.FindAsync(Id);
            if (products == null) Results.NotFound("Product not found");
            products.Name = product.Name;
            products.Description = product.Description;
            products.Price = product.Price;
            _context.Product.Update(products);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProductById(Product product)
        {   
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
