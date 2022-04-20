namespace OnlineWalmart.DAL
{
    public class Price
    {
        public double Value { get; set; }

        public double GetDiscountedPrice(double percentage)
        {
            return Value * percentage / 100.0;
        }
        public void SetDiscountedPrice(double percentage)
        {
            Value = Value * percentage / 100.0;
        }
    }
}
