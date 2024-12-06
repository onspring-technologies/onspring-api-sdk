using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Tests.Infrastructure;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using Onspring.API.SDK.Tests.Infrastructure.Http;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

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
        public async Task GetReportsForAppAsync()
        {
            var pagingRequest = new PagingRequest(1, 10);

            var getResponse = await _apiClient.CreateRequest()
                .ToGetReports()
                .FromApp(_appIdWithReports)
                .ForPage(pagingRequest.PageNumber)
                .WithPageSize(pagingRequest.PageSize)
                .SendAsync();
            
            AssertHelper.AssertSuccess(getResponse);
            AssertHelper.AssertPaging(pagingRequest, getResponse.Value);
        }

        [TestMethod]
        public async Task GetReportsForAppAsync_WithOptions()
        {
            var pagingRequest = new PagingRequest(1, 10);
            
            var getResponse = await _apiClient.CreateRequest()
                .ToGetReports()
                .FromApp(_appIdWithReports)
                .SendAsync(options =>
                {
                    options.PageNumber = pagingRequest.PageNumber;
                    options.PageSize = pagingRequest.PageSize;
                });
            
            AssertHelper.AssertSuccess(getResponse);
            AssertHelper.AssertPaging(pagingRequest, getResponse.Value);
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