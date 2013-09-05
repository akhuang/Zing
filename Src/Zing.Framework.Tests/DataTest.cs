using Autofac;
using NUnit.Framework;
using System;
using Zing.Data;
using Zing.Framework.Security;
using Zing.Logging;
using Zing.Modules.Users;
using Zing.Modules.Users.Models;
using Zing.Modules.Users.Services;
using System.Collections.Generic;
using System.Linq;

namespace Zing.Framework.Tests
{
    [TestFixture]
    public class DataTest : ContainerTestBase
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

        [Test]
        public void TestFetchByName()
        {
            var membershipService = _container.Resolve<IMembershipServiceInModule>();
            var model = membershipService.Fetch(x => x.NormalizedUserName == "dds");

            Assert.IsNotNull(model);
        }

        [Test]
        public void TestFetchAll()
        {
            var membershipService = _container.Resolve<IMembershipServiceInModule>();

            var count = membershipService.Count(x => x.NormalizedUserName == "322324232");

            IEnumerable<UserEntity> list = membershipService.Fetch(x => x.NormalizedUserName == "322324232", x => x.Asc(d => d.NormalizedUserName), 0, 5);

            Assert.IsNotNull(list);
            Assert.AreNotEqual(count, list.Count());
            Assert.AreEqual(list.Count(), 5);

        }
    }
}
