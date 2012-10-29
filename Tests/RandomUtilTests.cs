using DotNetUtils;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Tests
{
    [TestFixture]
    public class RandomUtilTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public void Bool(bool result)
        {
            int attempts = 0;
            do
            {
                if (RandomUtil.Bool() == result)
                {
                    Assert.Pass("Returned {0} after {1} attempts",result,attempts);
                }
            } while (attempts++ < 10000);
            Assert.Fail();
        }
    }
}