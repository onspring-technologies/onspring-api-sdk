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
            var pagingRequest = new PagingRequest(1, 10);
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetRecords()
                .FromApp(_appIdWithRecords)
                .ForPage(pagingRequest.PageNumber)
                .WithPageSize(pagingRequest.PageSize)
                .WithFieldIds(new[] { 1, 2, 3 })
                .WithFormat(DataFormat.Formatted)
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
            AssertHelper.AssertCasting(apiResponse.Value.Items);
        }

        [TestMethod]
        public async Task GetRecordsByApp_UsingOptions()
        {
            var pagingRequest = new PagingRequest(1, 10);
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetRecords()
                .FromApp(_appIdWithRecords)
                .ForPage(1)
                .SendAsync(opts =>
                {
                    opts.PageSize = pagingRequest.PageSize;
                    opts.Format = DataFormat.Formatted;
                    opts.FieldIds = new[] { 1, 2, 3 };
                });

            AssertHelper.AssertSuccess(apiResponse);
            AssertHelper.AssertCasting(apiResponse.Value.Items);
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

            AssertHelper.AssertSuccess(apiResponse);
            AssertHelper.AssertCasting(apiResponse.Value);
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
                    options.Format = DataFormat.Formatted;
                });

            AssertHelper.AssertSuccess(apiResponse);
            AssertHelper.AssertCasting(apiResponse.Value);
        }

        [TestMethod]
        public async Task GetRecordsByIds()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetRecords()
                .FromApp(_appIdWithRecords)
                .WithIds(new[] { 1, 2, 3 })
                .WithFieldIds(new[] { 1, 2, 3 })
                .WithFormat(DataFormat.Formatted)
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
            AssertHelper.AssertCasting(apiResponse.Value.Items);
        }

        [TestMethod]
        public async Task GetRecordsByIds_UsingOptions()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetRecords()
                .FromApp(_appIdWithRecords)
                .WithIds(new[] { 1, 2, 3 })
                .SendAsync(options =>
                {
                    options.Format = DataFormat.Formatted;
                    options.FieldIds = new[] { 1, 2, 3 };
                });

            AssertHelper.AssertSuccess(apiResponse);
            AssertHelper.AssertCasting(apiResponse.Value.Items);
        }

        [TestMethod]
        public async Task QueryRecords()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetRecords()
                .FromApp(_appIdWithRecords)
                .WithFilter($"{1} eq {1}")
                .ForPageNumber(1)
                .WithPageSize(50)
                .WithFieldIds(new[] { 1, 2, 3 })
                .WithFormat(DataFormat.Formatted)
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
            AssertHelper.AssertCasting(apiResponse.Value.Items);
        }

        [TestMethod]
        public async Task QueryRecords_UsingOptions()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetRecords()
                .FromApp(_appIdWithRecords)
                .WithFilter(filter =>
                {
                    filter.FieldId = 1;
                    filter.Operator = FilterOperator.Equal;
                    filter.Value = 1;
                })
                .SendAsync(options =>
                {
                    options.PageNumber = 1;
                    options.PageSize = 50;
                    options.FieldIds = new[] { 1, 2, 3 };
                    options.Format = DataFormat.Formatted;
                });

            AssertHelper.AssertSuccess(apiResponse);
            AssertHelper.AssertCasting(apiResponse.Value.Items);
        }

        [TestMethod]
        public async Task DeleteRecord()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToDeleteRecords()
                .FromApp(1)
                .WithId(1)
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
        }

        [TestMethod]
        public async Task DeleteRecords()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToDeleteRecords()
                .FromApp(1)
                .WithIds(new[] { 1, 2, 3 })
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
        }

        [TestMethod]
        public async Task AddRecord()
        {
            var record = TestDataFactory.GetFullyFilledOutRecord(_appIdWithRecords, 1);

            var apiResponse = await _apiClient
                .CreateRequest()
                .ToSaveRecord()
                .InApp(record.AppId)
                .WithId(null)
                .WithValues(record.FieldData)
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
        }

        [TestMethod]
        public async Task UpdateRecord()
        {
            var record = TestDataFactory.GetFullyFilledOutRecord(_appIdWithRecords, 1);

            var apiResponse = await _apiClient
                .CreateRequest()
                .ToSaveRecord()
                .InApp(record.AppId)
                .WithId(record.RecordId)
                .WithValues(record.FieldData)
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
        }
    }
}