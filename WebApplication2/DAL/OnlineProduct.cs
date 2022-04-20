namespace OnlineWalmart.DAL
{
    public abstract class OnlineProduct : Product
    {
        public override string DeliveryInfo => "Delivery with Instabox within 0-2 working days";
    }
}
