namespace OnlineWalmart.DAL
{
    public class DiscountCodeValidator
    {
        public bool Validate(string code, DiscountCode[] validCodes, out DiscountCode? output)
        {
            output = validCodes.FirstOrDefault(c => c.Code == code);

            if (output == null)
                return false;
            return true;
        }
    }
}
