using ApplicationCore.Entities;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace OrderAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartItemController: ControllerBase
{
    private readonly ICartItemServiceAsync _cartItemServiceAsync;

    public CartItemController(ICartItemServiceAsync cartItemServiceAsync)
    {
        _cartItemServiceAsync = cartItemServiceAsync;
    }


    [HttpGet]
    [Route("getAllCartItems")]
    public async Task< IActionResult> GetAllCartItems()
    {
        return Ok( await _cartItemServiceAsync.GetAllCartItems());
    }
    
    //create new product
    [HttpPost]
    [Route("createNewCartItem")]
    public async Task<IActionResult> CreateNewCartItem(CartItem cartItem) 
    {
        if (cartItem == null) return BadRequest(new { message = "please enter required fields" });
        return Ok( await _cartItemServiceAsync.CreateCartItem(cartItem));
    }
    
    // update admin
    [HttpPut]
    [Route("updateCartItem")]
    public async Task<IActionResult> UpdateCartItem(CartItem cartItem)
    {
        if (cartItem.ItemId == null || cartItem.CustomerId == null || cartItem.ProductId == null) 
            return BadRequest(new { message = "please enter required fields" });
        return Ok( await _cartItemServiceAsync.UpdateCartItem(cartItem));
    }
    
    // delete Admin
    [HttpDelete]
    [Route("deleteCartItem")]
    public async Task<IActionResult> DeleteCartItem( [FromQuery]  int itemId)
    {
        if (itemId == null) return BadRequest();
        return Ok( await _cartItemServiceAsync.DeleteCartItem(itemId));
    }
    
    
}