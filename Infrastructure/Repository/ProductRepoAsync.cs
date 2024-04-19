using ApplicationCore.Entities;
using ApplicationCore.Repository;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class ProductRepoAsync: BaseRepositoryAsync<Product>, IProductRepoAsync
{
    public ProductRepoAsync(ProductDbContext productDbContext) : base(productDbContext)
    {
    }
    
}