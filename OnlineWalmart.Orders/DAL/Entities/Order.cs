using System.ComponentModel.DataAnnotations;

namespace OnlineWalmart.Orders.DAL.Entities;

public class Order
{
    public int Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public DateTimeOffset DateOfPurchase { get; set; }
    [Range(0f, 100f)]
    public float DiscountInPercent { get; set; }
}
