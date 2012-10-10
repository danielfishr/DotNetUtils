using System;
using DotNetUtils;
using NUnit.Framework;
// ReSharper disable InconsistentNaming
namespace Tests
{
    [TestFixture]
    public class EnumUtilTests
    {
        public enum Mock
        {
            Foo,
            Bar,
            Baz
        }

        [TestCase("Foo",Mock.Foo)]
        [TestCase("foo", Mock.Foo, ExpectedException = typeof(ArgumentException))]
        public void Parse(string text, Mock expected)
        {
            var actual = EnumUtil.Parse<Mock>(text);
        
            Assert.That(actual,Is.EqualTo(expected));
        }

        [TestCase("Foo", Mock.Foo)]
        [TestCase("foo", Mock.Foo)]
        public void Parse_IgnoreCase(string text, Mock expected)
        {
            var actual = EnumUtil.Parse<Mock>(text,true);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("Foo", Mock.Foo)]
        [TestCase("foo", Mock.Bar)]
        public void Parse_DefaultBar(string text, Mock expected)
        {
            var actual = EnumUtil.Parse(text,Mock.Bar);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}