namespace OnlineWalmart.DAL
{
    public class OnlineCoffeeBeans : OnlineProduct
    {
        public override string Name { get; }

        public override string Description { get; }

        public override IPrice Price { get; }
    }
}
