using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Tests.Infrastructure;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using Onspring.API.SDK.Tests.Infrastructure.Http;
using RichardSzalay.MockHttp;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests.Integration
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OnspringClientFieldTests
    {
        private const int _appIdWithFields = 1;
        private static readonly int[] _fields = new[] { 1, 2, 3, 4, 5 };

        private static OnspringClient _apiClient;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var testConfiguration = TestConfiguration.LoadFromContext(testContext);
            var httpClient = HttpClientFactory.GetHttpClient(testConfiguration);

            _apiClient = new OnspringClient(testConfiguration.ApiKey, httpClient);
        }

        [TestMethod]
        public async Task GetFieldAsync()
        {
            var getResponse = await _apiClient.GetFieldAsync(_fields.First());
            AssertHelper.AssertSuccess(getResponse);
        }

        [TestMethod]
        public async Task GetFieldsAsync()
        {
            var getResponse = await _apiClient.GetFieldsAsync(_fields);
            AssertHelper.AssertSuccess(getResponse);
        }

        [TestMethod]
        public async Task GetFieldsForAppAsync()
        {
            var getResponse = await _apiClient.GetFieldsForAppAsync(_appIdWithFields);
            AssertHelper.AssertSuccess(getResponse);
        }

        [TestMethod]
        public async Task GetAllFieldsForAppAsync_WhenUsingDefaultPageSize_ReturnsAllFields()
        {
            var testAddress = "https://localhost";

            var numberOfFields = 3;
            var pageSize = 50;
            var pages = TestDataFactory.GetPagesOfFields(numberOfFields, pageSize);

            var mockHttp = new MockHttpMessageHandler();

            foreach (var page in pages)
            {
                mockHttp
                    .When(HttpMethod.Get, $"{testAddress}/fields/appId/1?PageNumber={page.PageNumber}&PageSize={pageSize}")
                    .Respond(
                        "application/json",
                        JsonSerializer.Serialize(page)
                    );
            }

            var mockHttpClient = mockHttp.ToHttpClient();
            mockHttpClient.BaseAddress = new(testAddress);

            var apiClient = new OnspringClient("test", mockHttpClient);

            var fieldsResponse = apiClient.GetAllFieldsForAppAsync(1);

            var responsePages = new List<GetPagedFieldsResponse>();

            await foreach (var response in fieldsResponse)
            {
                AssertHelper.AssertSuccess(response);
                responsePages.Add(response.Value);
            }

            foreach (var page in pages)
            {
                var responsePage = responsePages.Single(x => x.PageNumber == page.PageNumber);

                Assert.AreEqual(page.PageNumber, responsePage.PageNumber);
                Assert.AreEqual(page.Items.Count, responsePage.Items.Count);
                Assert.AreEqual(page.Items[0].Id, responsePage.Items[0].Id);
            }
        }

        [TestMethod]
        public async Task GetAllFieldsForAppAsync_WhenUsingSpecificPageSize_ReturnsAllFields()
        {
            var testAddress = "https://localhost";

            var numberOfFields = 3;
            var pageSize = 1;
            var pages = TestDataFactory.GetPagesOfFields(numberOfFields, pageSize);

            var mockHttp = new MockHttpMessageHandler();

            foreach (var page in pages)
            {
                mockHttp
                    .When(HttpMethod.Get, $"{testAddress}/fields/appId/1?PageNumber={page.PageNumber}&PageSize={pageSize}")
                    .Respond(
                        "application/json",
                        JsonSerializer.Serialize(page)
                    );
            }

            var mockHttpClient = mockHttp.ToHttpClient();
            mockHttpClient.BaseAddress = new(testAddress);

            var apiClient = new OnspringClient("test", mockHttpClient);

            var fieldsResponse = apiClient.GetAllFieldsForAppAsync(appId: 1, pageSize: 1);

            var responsePages = new List<GetPagedFieldsResponse>();

            await foreach (var response in fieldsResponse)
            {
                AssertHelper.AssertSuccess(response);
                responsePages.Add(response.Value);
            }

            foreach (var page in pages)
            {
                var responsePage = responsePages.Single(x => x.PageNumber == page.PageNumber);

                Assert.AreEqual(page.PageNumber, responsePage.PageNumber);
                Assert.AreEqual(page.Items.Count, responsePage.Items.Count);
                Assert.AreEqual(page.Items[0].Id, responsePage.Items[0].Id);
            }
        }
    }
}