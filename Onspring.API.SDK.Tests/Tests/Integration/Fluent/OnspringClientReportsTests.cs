using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Tests.Infrastructure;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using Onspring.API.SDK.Tests.Infrastructure.Http;

namespace Onspring.API.SDK.Tests.Tests.Integration.Fluent
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
        public async Task GetReportData()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetReportData()
                .FromReport(_reportId)
                .WithFormat(DataFormat.Formatted)
                .WithDataType(ReportDataType.ChartData)
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
        }

        [TestMethod]
        public async Task GetReportData_WithOptions()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetReportData()
                .FromReport(_reportId)
                .SendAsync(options =>
                {
                    options.Format = DataFormat.Formatted;
                    options.DataType = ReportDataType.ChartData;
                });

            AssertHelper.AssertSuccess(apiResponse);
        }
    }
}