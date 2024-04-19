using ApplicationCore.Entities;
using ApplicationCore.Model;

namespace ApplicationCore.Services;

public interface ICartItemServiceAsync
{
    Task<IEnumerable<CartItem>> GetAllCartItems();
    Task<IEnumerable<CartItemResponseModel>> GetAllCartItemResponseModels();
    Task<int> CreateCartItem(CartItem cartItem);
    Task<int> UpdateCartItem(CartItem cartItem);
    Task<int> DeleteCartItem(int itemId);
    Task<decimal> CalculateThisCartItem(int productId, int qty);
    Task<CartItem> GetByItemIdAsync(int itemId);
    //CartItem GetCartItemByCustomerIdAndProductId(int customerId, int productId);
}