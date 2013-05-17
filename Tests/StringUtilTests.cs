using DotNetUtils;
using NUnit.Framework;
// ReSharper disable InconsistentNaming
namespace Tests
{
    [TestFixture]
    public class StringUtilTests
    {
        [Test]
        public void RemoveNoneDigits_WorksFine()
        {
            const string str = " abc12 d3 e ";

            Assert.That(StringUtil.RemoveNoneDigits(str),Is.EqualTo("123"));
        }

        [TestCase("A",true)]
        [TestCase("a",true)]
        [TestCase("ABc", true)]
        [TestCase("ABc D", true)]
        [TestCase("ABc d", true)]
        [TestCase("AbCd", false)]
        public void StringUtil_WorksFine(string str,bool expected)
        {
            Assert.That(StringUtil.IsSplitOnCamelCase(str),Is.EqualTo(expected));
        }
    }
}