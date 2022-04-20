namespace OnlineWalmart.DAL
{
    public abstract class OnlineProduct : Product
    {
        protected OnlineProduct(string name, string description, IPrice price) : base(name, description, price)
        {
        }
        public override string DeliveryInfo => "Delivery with Instabox within 0-2 working days";
    }
}
