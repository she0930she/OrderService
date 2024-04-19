using ApplicationCore.Entities;
using ApplicationCore.Repository;
using ApplicationCore.Services;

namespace Infrastructure.Services;

public class ShoppingCartServiceAsync: IShoppingCartServiceRepo
{
    private readonly IShoppingCartRepoAsync _shoppingCartRepoAsync;
    private readonly ICartItemRepoAsync _cartItemRepoAsync;
    private readonly IProductRepoAsync _productRepoAsync;

    public ShoppingCartServiceAsync(IShoppingCartRepoAsync shoppingCartRepoAsync, ICartItemRepoAsync cartItemRepoAsync, IProductRepoAsync productRepoAsync)
    {
        _shoppingCartRepoAsync = shoppingCartRepoAsync;
        _cartItemRepoAsync = cartItemRepoAsync;
        _productRepoAsync = productRepoAsync;
    }


    public async Task<IEnumerable<ShoppingCart>> GetAllShoppingCarts()
    {
        return await _shoppingCartRepoAsync.GetAllAsync();
    }

    public Task<int> AddToCart(CartItem cartItem)
    {
        var shopCart = _shoppingCartRepoAsync.SearchByCustomerId(cartItem.CustomerId);
        if (shopCart == null)
        {
            return CreateShoppingCart(cartItem);
        }
        
        // shopCart in DB
        throw new NotImplementedException();
        

    }

    public Task<int> AddItemListToCart(IEnumerable<CartItem> cartItemList)
    {
        throw new NotImplementedException();
    }


    public async Task<int> CreateShoppingCart(CartItem cartItem)
    {
        ShoppingCart shopCart = new ShoppingCart()
        {
            CustomerId = cartItem.CustomerId,
            ShoppingItemList = new List<CartItem>(),
            TotalPrice = cartItem.ProductTotal,
        };
        shopCart.ShoppingItemList.Add(cartItem); 

        return await _shoppingCartRepoAsync.InsertAsync(shopCart);
    }

    public Task<int> UpdateOneItemInCart(CartItem cartItem)
    {
        throw new NotImplementedException();
    }


    public Task<int> UpdateShoppingCart(IEnumerable<CartItem> cartItemList)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteShoppingCart(int cartId)
    {
        throw new NotImplementedException();
    }

    public Task<ShoppingCart> GetByCartIdAsync(int cartId)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> CalculateSubtotal()
    {
        throw new NotImplementedException();
    }
}