namespace OnlineWalmart.Products.DAL.Models;

public class ProductModelToBePosted
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Price { get; set; }
    public string DeliveryInfo { get; set; } = null!;
}
