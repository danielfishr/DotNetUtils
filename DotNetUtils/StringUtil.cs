using System.Text.RegularExpressions;

namespace DotNetUtils
{
    public static class StringUtil
    {
        public static string RemoveNoneDigits(string str)
        {
            return Regex.Replace(str, "[^.0-9]", "");
        }
    }
}