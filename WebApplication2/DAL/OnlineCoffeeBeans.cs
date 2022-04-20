namespace OnlineWalmart.DAL
{
    public class OnlineCoffeeBeans : OnlineProduct
    {
        public OnlineCoffeeBeans(string name, string description, IPrice price)
        {
            Name=name;
            Description=description;
            Price=price;
        }

        public override string Name { get; }

        public override string Description { get; }

        public override IPrice Price { get; }
    }
}
