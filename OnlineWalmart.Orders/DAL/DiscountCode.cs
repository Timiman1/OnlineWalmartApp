namespace OnlineWalmart.Orders.DAL
{
    public class DiscountCode
    {
        public DiscountCode(string code, float discount)
        {
            Code = code;
            DiscountInPercentage = discount;
        }

        public string Code { get; }

        public float DiscountInPercentage { get; }
    }
}
