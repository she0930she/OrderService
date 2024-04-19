using ApplicationCore.Entities;

namespace ApplicationCore.Services;

public interface IShoppingCartServiceRepo
{
    Task<IEnumerable<ShoppingCart>> GetAllShoppingCarts();
    Task<int> AddToCart(CartItem cartItem);
    Task<int> AddItemListToCart(IEnumerable<CartItem> cartItemList);
    
    Task<int> CreateShoppingCart(CartItem cartItem);
    Task<int> UpdateOneItemInCart(CartItem cartItem);
    Task<int> UpdateShoppingCart(IEnumerable<CartItem> cartItemList);
    Task<int> DeleteShoppingCart(int cartId);
    Task<ShoppingCart> GetByCartIdAsync(int cartId);
    Task<decimal> CalculateSubtotal();
}