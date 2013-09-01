using Autofac;
using NUnit.Framework;
using System;
using Zing.Data;
using Zing.Framework.Security;
using Zing.Logging;
using Zing.Modules.Users;
using Zing.Modules.Users.Models;
using Zing.Modules.Users.Services;

namespace Zing.Framework.Tests
{
    [TestFixture]
    public class UnitTest1 : ContainerTestBase
    {
        protected override void Register(ContainerBuilder builder)
        {
            //builder.RegisterModule(new DataModule());
            base.Register(builder);
            builder.RegisterModule(new UsersModule());

        }
        [Test]
        public void SumOfTwoNumbers()
        {
            Assert.AreEqual(5, 3 + 2);
        }

        [Test]
        public void TestGetUserById()
        {
            var tmp = _container.Resolve<IRepository<UserEntity>>();

            var userInfo = tmp.Get(22);

            Assert.IsNotNull(userInfo);
            Assert.AreEqual("ddd", userInfo.UserName);
        }

        [Test]
        public void TestGetUserInfoByIdInModule()
        {
            var tmp = _container.Resolve<IMembershipServiceInModule>();

            Assert.IsNotNull(tmp);

            var model = tmp.Get(22);

            Assert.IsNotNull(model);
            Assert.AreEqual("ddd", model.UserName);
        }

        [Test]
        public void TestGetUserInfoByUserName()
        {
            //ILogger Logger = _container.Resolve<ILogger>();
            //Logger.Debug("TestGetUserInfoByUserName");
            var membershipService = _container.Resolve<IMembershipService>();
            var model = membershipService.GetUser("ddd2");

            Assert.IsNotNull(model);
        }
    }
}
