using DotNetUtils;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ListUtilTests
    {
        [TestCase(null,null,null,null)]
        [TestCase(null, null,"" ,null)]
        [TestCase(null, null, "", null)]
        [TestCase("a", "b", "c", "a")]
        public void FirstNotNullOrWhitespace(string first,string second,string third,string expected)
        {
            //act
            string actual = ListUtil.FirstNotNullOrWhitespace(first,second,third);

            //assert
            Assert.That(actual,Is.EqualTo(expected));
        }
    }
}