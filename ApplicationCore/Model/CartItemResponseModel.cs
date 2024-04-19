namespace ApplicationCore.Model;

public class CartItemResponseModel
{
    public int ItemId { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal ProductTotal { get; set; } // unitPrice* quantity
}