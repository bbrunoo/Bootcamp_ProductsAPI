using Bootcamp_Task_FullAPI.Entities;

namespace Bootcamp_Task_FullAPI.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductByIdAsync(Guid Id);
        Task<Product> PostProduct(Product Product);
        Task UpdateProductById(Guid Id, Product Product);
        Task DeleteProductById(Product product);
    }
}
