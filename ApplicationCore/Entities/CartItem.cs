using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class CartItem
{
    [Key]
    public int ItemId { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    //public virtual Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal ProductTotal { get; set; } // unitPrice* quantity
}