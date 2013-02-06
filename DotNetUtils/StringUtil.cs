using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DotNetUtils
{
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
    }
}