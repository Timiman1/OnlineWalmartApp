namespace OnlineWalmart.DAL
{
    public class DiscountCodeValidator
    {
        public bool Validate(string code, DiscountCode[] validCodes, Product productToDiscount)
        {
            var discountCode = validCodes.FirstOrDefault(c => c.Code == code);

            if (discountCode == null)
                return false;
            else
            {
                productToDiscount.Discount = discountCode.Discount;
                return true;
            }
        }
    }
}
