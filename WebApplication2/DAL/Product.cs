namespace OnlineWalmart.DAL
{
    public abstract class Product
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract IPrice Price { get; }
        public abstract string DeliveryInfo { get; }
    }
}
