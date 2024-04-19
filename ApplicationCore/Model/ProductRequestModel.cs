namespace ApplicationCore.Model;

public class ProductRequestModel
{
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int StockQuantity { get; set; }
    public string PictureUrl { get; set; }
    public string Description { get; set; }
}