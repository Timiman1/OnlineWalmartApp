namespace OnlineWalmart.Orders.DAL.Entities;

public class Order
{
    public int Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public DateTimeOffset DateOfPurchase { get; set; }
    public float DiscountInPercent { get; set; }
}
