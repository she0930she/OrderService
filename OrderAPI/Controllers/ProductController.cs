using ApplicationCore.Entities;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProductController: ControllerBase
{
    private readonly IProductServiceAsync _productServiceAsync;

    public ProductController(IProductServiceAsync productServiceAsync)
    {
        _productServiceAsync = productServiceAsync;
    }
    
    [HttpGet]
    [Route("getAllProducts")]
    public async Task< IActionResult> GetAllProducts()
    {
        return Ok( await _productServiceAsync.GetAllProducts());
    }
    
    // create new product
    [HttpPost]
    [Route("createNewProduct")]
    public async Task<IActionResult> AddNewAdmin(Product prud)
    {
        if (prud == null) return BadRequest(new { message = "please enter required fields" });
        return Ok( await _productServiceAsync.CreateNewProduct(prud));
    }
    
    // update admin
    [HttpPut]
    [Route("updateProduct")]
    //[Authorize]
    public async Task<IActionResult> UpdateProduct(Product prud)
    {
        if (prud == null || prud.Id == null) 
            return BadRequest(new { message = "please enter required fields" });
        return Ok( await _productServiceAsync.UpdateProductAsync(prud));
    }
    
    // delete Admin
    [HttpDelete]
    [Route("deleteProduct")]
    //[Authorize]
    public async Task<IActionResult> DeleteProduct( [FromQuery]  int prudId)
    {
        if (prudId == null) return BadRequest();
        return Ok( await _productServiceAsync.DeleteProductAsync(prudId));
    }
    
    
    
}