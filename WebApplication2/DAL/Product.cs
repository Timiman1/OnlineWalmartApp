namespace OnlineWalmart.DAL
{
    public abstract class Product
    {
        public virtual string Name { get; }
        public virtual string Description { get; }
        public virtual IPrice Price { get; }
        public virtual string DeliveryInfo { get; }

        protected Product(string name, string description, IPrice price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
