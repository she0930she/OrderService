

using ApplicationCore.Entities;
using ApplicationCore.Model;
using ApplicationCore.Repository;
using ApplicationCore.Services;

namespace Infrastructure.Services;

public class ProductServiceAsync: IProductServiceAsync
{
    private readonly IProductRepoAsync _productRepoAsync;

    public ProductServiceAsync(IProductRepoAsync productRepoAsync)
    {
        _productRepoAsync = productRepoAsync;
    }


    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _productRepoAsync.GetAllAsync();
    }
    

    public async Task<int> CreateNewProduct(Product prud)
    {
        return await _productRepoAsync.InsertAsync(prud);
    }

    public async Task<int> UpdateProductAsync(Product prud)
    {
        // var productTask = await _productRepoAsync.GetByIdAsync(prud.Id);
        // Product product = new Product()
        // {
        //     Id = productTask.Id,
        //     ProductName = prud.ProductName,
        //     UnitPrice = prud.UnitPrice,
        //     StockQuantity = prud.StockQuantity,
        //     PictureUrl = prud.PictureUrl,
        //     Description = prud.Description,
        // };
        
        return await _productRepoAsync.UpdateAsync(prud);
    }


    public async Task<int> DeleteProductAsync(int id)
    {
        return await _productRepoAsync.DeleteAsync(id);
    }

    public async Task<Product> GetByProductIdAsync(int id)
    {
        return await _productRepoAsync.GetByIdAsync(id);
    }
}