namespace OnlineWalmart.DAL
{
    public interface IPrice
    {
        double Value { get; set; }
        double Discount { get; set; } 
        double DiscountedValue { get; set; }
    }
}
