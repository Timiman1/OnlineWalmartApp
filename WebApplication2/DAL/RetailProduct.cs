namespace OnlineWalmart.DAL
{
    public abstract class RetailProduct : Product
    {
        protected RetailProduct(string name, string description, IPrice price) : base(name, description, price)
        {
        }

        public override string DeliveryInfo => "Come and pick up in our store within 14 days.";
    }
}
