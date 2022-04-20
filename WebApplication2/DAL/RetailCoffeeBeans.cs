namespace OnlineWalmart.DAL
{
    public class RetailCoffeeBeans : Product
    {
        public override string Name { get;  }

        public override string Description { get; }

        public override IPrice Price { get; }

        public override string DeliveryInfo { get; }
    }
}
