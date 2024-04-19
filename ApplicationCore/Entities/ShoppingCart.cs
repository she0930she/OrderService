using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class ShoppingCart
{
    [Key]
    public int CartId { get; set; }
    public int CustomerId { get; set; }
    public List<CartItem> ShoppingItemList { get; set; }
    public decimal TotalPrice { get; set; }
    
    
}