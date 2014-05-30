namespace DotNetUtils
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class StringUtil
    {
        public static string RemoveNoneDigits(string str)
        {
            return Regex.Replace(str, "[^.0-9]", "");
        }

        public static bool IsSplitOnCamelCase(string str)
        {
            IList<int> indexes = new List<int>();
            for (int i = 1; i < str.Length; i++)
            {
                if (char.IsUpper(str[i]))
                {
                    indexes.Add(i);
                }
            }
            foreach (var index in indexes)
            {
                if (str[index - 1] != ' ' && !char.IsUpper(str[index - 1]))
                {
                    return false;
                }
            }
            return true;
        }

        public static string FirstNoneEmptyOrWhitespce(params string[] strs)
        {
            if (strs == null)
            {
                return null;
            }
            return strs.FirstOrDefault(x => !string.IsNullOrWhiteSpace(x));
        }

        public static string TrimToLengthWithPostfix(int len, string input, string postfix)
        {
            if (input != null && input.Length > len)
            {
                len = len - (postfix ?? "").Length;
                return input.Substring(0, len) + postfix;
            }
            return input;
        }
    }
}