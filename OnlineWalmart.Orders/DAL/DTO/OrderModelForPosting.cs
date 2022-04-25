using System.ComponentModel.DataAnnotations;

namespace OnlineWalmart.Orders.DAL.DTO;

public class OrderModelForPosting
{
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public string DiscountCode { get; set; } = null!;
}
