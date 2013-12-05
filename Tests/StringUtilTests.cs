using System.Runtime.CompilerServices;
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

        [TestCase("dan",3,".","dan")]
        [TestCase("dan",6,"...","dan")]
        [TestCase("Daniel",4,".","Dan.")]
        [TestCase(null,3,null,null)]
        [TestCase(null,3,".",null)]
        [TestCase("Daniel", 3, null, "Dan")]
        [TestCase("Daniel", 3, "", "Dan")]        
        public void TrimToLengthWithPostfix(string input, int len, string postfix, string expected)
        {
            Assert.That(StringUtil.TrimToLengthWithPostfix(len, input, postfix), Is.EqualTo(expected));
        }
    }
}