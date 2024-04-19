using ApplicationCore.Entities;
using ApplicationCore.Repository;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class ShoppingCartRepoAsync: BaseRepositoryAsync<ShoppingCart>, IShoppingCartRepoAsync
{
    private readonly ProductDbContext _productDbContext;
    public ShoppingCartRepoAsync(ProductDbContext productDbContext) : base(productDbContext)
    {
        _productDbContext = productDbContext;
    }

    public ShoppingCart SearchByCustomerId(int customerId)
    {
        var res =  _productDbContext.ShoppingCarts.Where(
            cart => cart.CustomerId == customerId
        ).FirstOrDefault();
        return res;
    }
}