namespace OnlineWalmart.DAL
{
    public class DiscountCode
    {
        public DiscountCode(string code, double discount)
        {
            Code = code;
            Discount = discount;
        }

        public string Code { get; }

        public double Discount { get; }
    }
}
