namespace OnlineWalmart.DAL
{
    public class Price
    {
        double Value { get; }
        double Discount { get; } 
        double DiscountedValue { get; }

        public Price(double value, double discount)
        {
            Value = value;
            Discount = discount;
            DiscountedValue = value * (discount / 100.0);
        }
    }
}
