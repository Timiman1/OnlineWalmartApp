namespace OnlineWalmart.Orders.DAL.DTO
{
    public class OrderModelForPosting
    {
        
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public DateTimeOffset DateOfPurchase { get; set; }
        public float DiscountInPercent { get; set; }
    }
}
