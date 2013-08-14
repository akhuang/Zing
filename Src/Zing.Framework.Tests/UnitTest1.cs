using NUnit.Framework;
using System;

namespace Zing.Framework.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void SumOfTwoNumbers()
        {
            Assert.AreEqual(5, 3 + 2);
        }
    }
}
