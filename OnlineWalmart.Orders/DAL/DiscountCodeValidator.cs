using OnlineWalmart.Orders.DAL.Entities;

namespace OnlineWalmart.Orders.DAL
{
    public class DiscountCodeValidator
    {
        public bool Validate(string code, DiscountCode[] validCodes, Order orderToDiscount)
        {
            var discountCode = validCodes.FirstOrDefault(c => c.Code == code);

            if (discountCode == null)
                return false;
            else
            {
                orderToDiscount.DiscountInPercent = discountCode.DiscountInPercentage;
                return true;
            }
        }
    }
}
