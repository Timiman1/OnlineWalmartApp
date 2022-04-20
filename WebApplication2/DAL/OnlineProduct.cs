namespace OnlineWalmart.DAL
{
    public sealed class OnlineProduct : Product
    {
        protected OnlineProduct(string name, string description, Price price) : base(name, description, price)
        {
        }
        public override string DeliveryInfo => "Delivery with Instabox within 0-2 working days";
    }
}
