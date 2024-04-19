using ApplicationCore.Entities;

namespace ApplicationCore.Repository;

public interface ICartItemRepoAsync: IRepositoryAsync<CartItem>
{
    CartItem GetCartItemByCustomerIdAndProductId(int customerId, int productId);
}