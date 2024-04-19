
using ApplicationCore.Entities;
using ApplicationCore.Repository;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class CartItemRepoAsync: BaseRepositoryAsync<CartItem>, ICartItemRepoAsync
{
    private readonly ProductDbContext _productDbContext;
    public CartItemRepoAsync(ProductDbContext productDbContext) : base(productDbContext)
    {
        _productDbContext = productDbContext;
    }

    public CartItem GetCartItemByCustomerIdAndProductId(int customerId, int productId)
    {
        var res =  _productDbContext.CartItems.Where(
            item => item.CustomerId == customerId && item.ProductId == productId
        ).FirstOrDefault();
        return res;
    }


}