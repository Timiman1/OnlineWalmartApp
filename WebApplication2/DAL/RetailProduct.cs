namespace OnlineWalmart.DAL
{
    public abstract class RetailProduct : Product
    {
        public override string DeliveryInfo => "Come and pick up in our store within 14 days.";
    }
}
