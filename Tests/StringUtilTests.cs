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

            Assert.That(StringUtil.RemoveNoneDigits(str),Is.EqualTo(" abc d e "));
        }
    }
}