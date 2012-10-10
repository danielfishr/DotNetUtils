using DotNetUtils;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class InvokeUtilTests
    {

        private class MockClass
        {
            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }
            public MockClass(int a, int b, int c)
            {
                A = a;
                B = b;
                C = c;
            }

            public void IncrementA(int a)
            {
                A += a;
            }
        }

        public class MockDto
        {
            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }
        }

        private MockClass @class;

        [Test]
        public void InvokeCtor()
        {

            var dto = new MockDto
                {
                    A = 1,
                    B = 2,
                    C = 3
                };

            @class = InvokeUtil.InvokeCtor<MockClass,MockDto>(dto);

            Assert.That(@class.A,Is.EqualTo(dto.A));
        }

        [Test]
        public void InvokeWithDto()
        {

            InvokeCtor();

            @class.InvokeWithDto("IncrementA", new MockDto() {A = 10});

            Assert.That(@class.A, Is.EqualTo(11));
        }
    }
}