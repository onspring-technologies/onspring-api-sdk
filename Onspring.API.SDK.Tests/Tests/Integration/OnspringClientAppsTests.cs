using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Tests.Infrastructure;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using Onspring.API.SDK.Tests.Infrastructure.Http;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests.Integration
{
    [TestClass, ExcludeFromCodeCoverage]
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
        public async Task GetAppsAsync()
        {
            var appsResponse = await _apiClient.GetAppsAsync();

            AssertHelper.AssertSuccess(appsResponse);
            Assert.IsTrue(appsResponse.Value.Items.Any(), "No items returned.");
        }

        [TestMethod]
        public async Task GetApps_WithPaging()
        {
            var pagingRequest = new Models.PagingRequest(1, 50);
            var appsResponse = await _apiClient.GetAppsAsync(pagingRequest);

            AssertHelper.AssertSuccess(appsResponse);
            AssertHelper.AssertPaging(pagingRequest, appsResponse.Value);
        }

        [TestMethod]
        public async Task GetAppByIdAsync()
        {
            var appResponse = await _apiClient.GetAppAsync(1);

            AssertHelper.AssertSuccess(appResponse);
        }

        [TestMethod]
        public async Task GetAppById_Unauthorized()
        {
            var appResponse = await _apiClient.GetAppAsync(401);

            AssertHelper.AssertError(appResponse, HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task GetAppById_Forbidden()
        {
            var appResponse = await _apiClient.GetAppAsync(403);

            AssertHelper.AssertError(appResponse, HttpStatusCode.Forbidden, true);
        }

        [TestMethod]
        public async Task GetAppById_NotFound()
        {
            var appResponse = await _apiClient.GetAppAsync(404);

            AssertHelper.AssertError(appResponse, HttpStatusCode.NotFound, true);
        }

        [TestMethod]
        public async Task GetAppsBatchAsync()
        {
            var ids = new[] { 1, 2, 3 };
            var getAppsResponse = await _apiClient.GetAppsAsync(ids);

            AssertHelper.AssertSuccess(getAppsResponse);
            Assert.IsTrue(getAppsResponse.Value.Items.Any(), "No items returned.");
            Assert.AreEqual(ids.Length, getAppsResponse.Value.Count, "Count was not correct.");
        }

        [TestMethod]
        public async Task GetAppsBatch_Unauthorized()
        {
            var ids = new[] { 401 };
            var getAppsResponse = await _apiClient.GetAppsAsync(ids);

            AssertHelper.AssertError(getAppsResponse, HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task GetAppsBatch_Forbidden()
        {
            var ids = new[] { 403 };
            var getAppsResponse = await _apiClient.GetAppsAsync(ids);

            AssertHelper.AssertError(getAppsResponse, HttpStatusCode.Forbidden);
        }
    }
}