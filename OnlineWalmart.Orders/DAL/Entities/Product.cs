namespace OnlineWalmart.Orders.DAL.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string DeliveryInfo { get; set; }
}
