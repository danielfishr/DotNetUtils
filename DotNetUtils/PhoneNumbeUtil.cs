namespace DotNetUtils
{
    public static class PhoneNumbeUtil
    {
        public static bool LooksLikeMobileNumber(string phoneNumber)
        {
            string digits = StringUtil.RemoveNoneDigits(phoneNumber).Replace(" ", string.Empty);
            return (digits.StartsWith("07") && digits.Length == 11) || (digits.StartsWith("447") && digits.Length == 12);
        }
    }
}