using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests.Integration.Fluent
{
    public class ConnectionRequestBuilderTests
    {
        private static IOnspringClient _client;
        private static ConnectionRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new ConnectionRequestBuilder(_client);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalled_ItShouldReturnBooleanConnectionIndicator()
        {
            var canConnect = false;

            _client.CanConnectAsync().Returns(canConnect);

            var result = await _builder.SendAsync();

            Assert.AreEqual(canConnect, result);
        }
    }
}