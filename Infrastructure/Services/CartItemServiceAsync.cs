using ApplicationCore.Entities;
using ApplicationCore.Model;
using ApplicationCore.Repository;
using ApplicationCore.Services;

namespace Infrastructure.Services;

public class CartItemServiceAsync: ICartItemServiceAsync
{
    private readonly ICartItemRepoAsync _cartItemRepoAsync;
    private readonly IProductRepoAsync _productRepoAsync;

    public CartItemServiceAsync(ICartItemRepoAsync cartItemRepoAsync, IProductRepoAsync productRepoAsync)
    {
        _cartItemRepoAsync = cartItemRepoAsync;
        _productRepoAsync = productRepoAsync;
    }


    public async Task<IEnumerable<CartItem>> GetAllCartItems()
    {
        return await _cartItemRepoAsync.GetAllAsync();
    }

    public Task<IEnumerable<CartItemResponseModel>> GetAllCartItemResponseModels()
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateCartItem(CartItem cartItem)
    {
        var resCartItem = _cartItemRepoAsync.GetCartItemByCustomerIdAndProductId(cartItem.CustomerId, cartItem.ProductId);
        // if usr has created same productId in cartItem, update it
        if (resCartItem != null) // cartItem in DB, need update not create
        {
            resCartItem.Quantity = cartItem.Quantity; // update CartItem
            return await _cartItemRepoAsync.UpdateAsync(resCartItem);
        }

        cartItem.ProductTotal = await CalculateThisCartItem(cartItem.ProductId, cartItem.Quantity);
        
        return await _cartItemRepoAsync.InsertAsync(cartItem);
    }

    public async Task<int> UpdateCartItem(CartItem cartItem)
    {
        cartItem.ProductTotal = await CalculateThisCartItem(cartItem.ProductId, cartItem.Quantity);
        
        return await _cartItemRepoAsync.UpdateAsync(cartItem);
    }

    public async Task<int> DeleteCartItem(int itemId)
    {
        return await _cartItemRepoAsync.DeleteAsync(itemId);
    }

    public async Task<decimal> CalculateThisCartItem(int productId, int qty)
    {
        var prud = await _productRepoAsync.GetByIdAsync(productId);
        return prud.UnitPrice * qty;

    }

    public async Task<CartItem> GetByItemIdAsync(int itemId)
    {
        return await _cartItemRepoAsync.GetByIdAsync(itemId);
    }

     public CartItem GetCartItemByCustomerIdAndProductId(int customerId, int productId)
     {
         var usr =  _cartItemRepoAsync.GetCartItemByCustomerIdAndProductId(customerId, productId);
         return usr;
     }

}