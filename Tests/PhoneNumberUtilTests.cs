using DotNetUtils;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PhoneNumberUtilTests
    {
        [TestCase("+447732556299", true)]
        [TestCase("07732556299", true)]
        [TestCase("0773-255-6299", true)]
        [TestCase("0161-255-6299", false)]
        [TestCase("077123", false)]
        public void LooksLikeMobileNumber(string number, bool expected)
        {
            Assert.That(PhoneNumbeUtil.LooksLikeMobileNumber(number),Is.EqualTo(expected));
        }
    }
}