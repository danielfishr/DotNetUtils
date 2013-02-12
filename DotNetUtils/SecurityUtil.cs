using System;
using System.Security.Cryptography;

namespace DotNetUtils
{
    public class SecurityUtil
    {
        public static string RandomPassword(int passwordLength)
        {
            return RandomPassword(passwordLength,
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!£$%&*()");
        }

        public static string RandomPassword(int passwordLength, string allowedChars)
        {
            var randomBytes = new Byte[passwordLength];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);
            var chars = new char[passwordLength];
            int allowedCharCount = allowedChars.Length;

            for (int i = 0; i < passwordLength; i++) {
                chars[i] = allowedChars[randomBytes[i] % allowedCharCount];
            }

            return new string(chars);
        }
        public static byte[] RandomSalt(int len)
        {
            var saltBytes = new Byte[len];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(saltBytes);
            return saltBytes;
        }
        public static byte[] RandomSalt()
        {
            return RandomSalt(4);
        }

        public static byte[] GenerateSalt()
        {
            return RandomSalt();
        }

        public static byte[] GenerateSalt(int numBytes)
        {
            return RandomSalt(numBytes);
        }
    }
}