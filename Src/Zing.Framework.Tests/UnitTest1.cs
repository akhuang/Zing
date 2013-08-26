using Autofac;
using NUnit.Framework;
using System;
using Zing.Data;
using Zing.Modules.Users.Models;

namespace Zing.Framework.Tests
{
    [TestFixture]
    public class UnitTest1 : ContainerTestBase
    {
        protected override void Register(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataModule());
        }
        [Test]
        public void SumOfTwoNumbers()
        {
            Assert.AreEqual(5, 3 + 2);
        }

        public void TestGetUsers()
        {
            _container.Resolve(typeof(IRepository<UserEntity>));
        }
    }
}
