using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniLibs;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void add_config_success()
        {
            var config = new MiniConfig("configs");

            var portConfigKey = "port";

            var expectedPortValue = 1584;

            config.AddOrUpdate(portConfigKey, expectedPortValue.ToString());

            var isConfigExist = config.TryGet(portConfigKey, out int port);

            Assert.AreEqual(true, isConfigExist);

            Assert.AreEqual(expectedPortValue, port);
        }

        [TestMethod]
        public void write_configs_success()
        {
            var config = new MiniConfig();

            var portConfigKey = "port";

            var expectedPortValue = 1584;

            config.AddOrUpdate(portConfigKey, expectedPortValue.ToString());

            var isConfigExist = config.TryGet(portConfigKey, out int port);

            Assert.AreEqual(true, isConfigExist);

            Assert.AreEqual(expectedPortValue, port);

        }
    }
}
