using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Tests.Infrastructure;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using Onspring.API.SDK.Tests.Infrastructure.Http;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OnspringClientRecordsTests
    {
        private const int _appIdWithRecords = 1;
        private const int _fieldId = 1;

        private static OnspringClient _apiClient;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var testConfiguration = TestConfiguration.LoadFromContext(testContext);
            var httpClient = HttpClientFactory.GetHttpClient(testConfiguration);

            _apiClient = new OnspringClient(testConfiguration.ApiKey, httpClient);
        }

        [TestMethod]
        public async Task GetRecordsByApp()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetRecords()
                .FromApp(_appIdWithRecords)
                .ForPage(1)
                .WithPageSize(50)
                .WithFieldIds(new[] { 1, 2, 3 })
                .WithFormat(DataFormat.Formatted)
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
        }

        [TestMethod]
        public async Task GetRecordsByApp_UsingOptions()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetRecords()
                .FromApp(_appIdWithRecords)
                .SendAsync(opts =>
                {
                    opts.PageNumber = 50;
                    opts.PageSize = 50;
                    opts.DataFormat = DataFormat.Formatted;
                    opts.FieldIds = new[] { 1, 2, 3 };
                });

            AssertHelper.AssertSuccess(apiResponse);
        }

        [TestMethod]
        public async Task GetRecordById()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetRecords()
                .FromApp(_appIdWithRecords)
                .WithId(1)
                .WithFieldIds(new[] { 1, 2, 3 })
                .WithFormat(DataFormat.Formatted)
                .SendAsync();
        }

        [TestMethod]
        public async Task GetRecordById_UsingOptions()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetRecords()
                .FromApp(_appIdWithRecords)
                .WithId(1)
                .SendAsync(options =>
                {
                    options.FieldIds = new[] { 1, 2, 3 };
                    options.DataFormat = DataFormat.Formatted;
                });
        }
    }
}