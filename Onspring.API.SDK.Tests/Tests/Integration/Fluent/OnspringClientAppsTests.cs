using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Tests.Infrastructure;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using Onspring.API.SDK.Tests.Infrastructure.Http;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests.Integration.Fluent
{
    public class OnspringClientAppsTests
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
        public async Task GetApp()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetApps()
                .WithId(1)
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
        }

        [TestMethod]
        public async Task GetAppsByIds()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetApps()
                .WithIds(new[] { 1, 2, 3 })
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
        }

        [TestMethod]
        public async Task GetApps()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetApps()
                .ForPage(1)
                .WithPageSize(25)
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
        }
    }
}