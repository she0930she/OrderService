using ApplicationCore.Entities;
using ApplicationCore.Model;

namespace ApplicationCore.Services;

public interface IProductServiceAsync
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<int> CreateNewProduct(Product prud);
    Task<int> UpdateProductAsync(Product prud);
    Task<int> DeleteProductAsync(int id);
    Task<Product> GetByProductIdAsync(int id);

}