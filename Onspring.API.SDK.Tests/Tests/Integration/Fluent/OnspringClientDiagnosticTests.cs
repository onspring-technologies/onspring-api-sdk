using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Tests.Infrastructure;
using Onspring.API.SDK.Tests.Infrastructure.Http;

namespace Onspring.API.SDK.Tests.Tests.Integration.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OnspringClientDiagnosticTests
    {
        private static OnspringClient _apiClient;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var testConfiguration = TestConfiguration.LoadFromContext(testContext);
            var httpClient = HttpClientFactory.GetHttpClient(testConfiguration);

            _apiClient = new OnspringClient(testConfiguration.ApiKey, httpClient);
        }

        [TestMethod]
        public async Task CanConnectAsync()
        {
            var canConnect = await _apiClient
                .CreateRequest()
                .ToCheckConnection()
                .SendAsync();

            Assert.IsTrue(canConnect, "Unable to connect");
        }
    }
}