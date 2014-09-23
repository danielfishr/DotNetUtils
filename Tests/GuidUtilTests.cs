using System;
using DotNetUtils;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class GuidUtilTests
    {
        [Test]
        public void Parse_OnGuidWithNoHypens()
        {
            Guid actual = GuidUtil.Parse("9fd82df07efd4613a4669401b053d8a0");

            Guid expected = Guid.Parse("9fd82df0-7efd-4613-a466-9401b053d8a0");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Parse_CanReturnNull()
        {
            Guid? actual = GuidUtil.TryParse("9fd82df0",null);

            Assert.That(actual, Is.Null);
        }
    }
}
