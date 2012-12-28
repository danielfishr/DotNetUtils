using System;

namespace DotNetUtils
{
    public static class FileUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size">bytes</param>
        /// <param name="format">e.g. {0:0.#}{1}. default is {0:0.##} {1}</param>
        /// <returns></returns>
        public static string HumanReadable(long size, string format = null)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            while (size >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                size = size / 1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            string result = String.Format(format ?? "{0:0.##} {1}", size, sizes[order]);
            return result;
        }
    }
}