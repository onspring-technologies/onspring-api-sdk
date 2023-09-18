using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Tests.Infrastructure;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using Onspring.API.SDK.Tests.Infrastructure.Http;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests.Integration
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OnspringClientReportsTests
    {
        private const int _appIdWithReports = 1;
        private const int _reportId = 1;

        private static OnspringClient _apiClient;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var testConfiguration = TestConfiguration.LoadFromContext(testContext);
            var httpClient = HttpClientFactory.GetHttpClient(testConfiguration);

            _apiClient = new OnspringClient(testConfiguration.ApiKey, httpClient);
        }

        [TestMethod]
        public async Task GetReportAsync()
        {
            var getResponse = await _apiClient.GetReportAsync(_reportId);
            AssertHelper.AssertSuccess(getResponse);
        }

        [TestMethod]
        public async Task GetReportsForAppAsync()
        {
            var pagingRequest = new PagingRequest(1, 10);
            var getResponse = await _apiClient.GetReportsForAppAsync(_appIdWithReports);
            AssertHelper.AssertSuccess(getResponse);
            AssertHelper.AssertPaging(pagingRequest, getResponse.Value);
        }
    }
}
