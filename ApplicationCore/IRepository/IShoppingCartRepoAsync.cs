using ApplicationCore.Entities;

namespace ApplicationCore.Repository;

public interface IShoppingCartRepoAsync: IRepositoryAsync<ShoppingCart>
{
    ShoppingCart SearchByCustomerId(int customerId);
}