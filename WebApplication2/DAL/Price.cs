namespace OnlineWalmart.DAL
{
    public class Price
    {
        public double Value { get; }
        public double Discount { get; }
        public double DiscountedValue => Value * Discount / 100.0;
    }
}
