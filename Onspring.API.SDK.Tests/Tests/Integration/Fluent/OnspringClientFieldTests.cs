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

namespace Onspring.API.SDK.Tests.Tests.Integration.Fluent
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
        public async Task GetField()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetFields()
                .WithId(_fields.First())
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
        }

        [TestMethod]
        public async Task GetFields()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetFields()
                .WithIds(_fields)
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
        }

        [TestMethod]
        public async Task GetFieldsFromApp()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetFields()
                .FromApp(_appIdWithFields)
                .ForPage(1)
                .WithPageSize(50)
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
        }

        [TestMethod]
        public async Task GetFieldsFromApp_WithOptions()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetFields()
                .FromApp(_appIdWithFields)
                .SendAsync(options =>
                {
                    options.PageNumber = 1;
                    options.PageSize = 25;
                });

            AssertHelper.AssertSuccess(apiResponse);
        }

        [TestMethod]
        public async Task GetAllFields_WhenUsingDefaultPageSize_ItShouldReturnAllPages()
        {
            var testAddress = "https://localhost";

            var numberOfFields = 3;
            var pageSize = 50;
            var pages = TestDataFactory.GetPagesOfFields(numberOfFields, pageSize);

            var mockHttp = new MockHttpMessageHandler();

            foreach (var page in pages)
            {
                mockHttp
                    .When(
                        HttpMethod.Get,
                        $"{testAddress}/fields/appId/{_appIdWithFields}?PageNumber={page.PageNumber}&PageSize={pageSize}"
                    )
                    .Respond(
                        "application/json",
                        JsonSerializer.Serialize(page)
                    );
            }

            var mockHttpClient = mockHttp.ToHttpClient();
            mockHttpClient.BaseAddress = new(testAddress);

            var apiClient = new OnspringClient("test", mockHttpClient);

            var fieldsResponses = apiClient
                .CreateRequest()
                .ToGetAllPages()
                .OfFields()
                .FromApp(_appIdWithFields)
                .SendAsync();

            var responsePages = new List<GetPagedFieldsResponse>();

            await foreach (var response in fieldsResponses)
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
        public async Task GetAllFields_WhenUsingCustomPageSize_ItShouldReturnAllPages()
        {
            var testAddress = "https://localhost";

            var numberOfFields = 3;
            var pageSize = 1;
            var pages = TestDataFactory.GetPagesOfFields(numberOfFields, pageSize);

            var mockHttp = new MockHttpMessageHandler();

            foreach (var page in pages)
            {
                mockHttp
                    .When(HttpMethod.Get, $"{testAddress}/fields/appId/{_appIdWithFields}?PageNumber={page.PageNumber}&PageSize={pageSize}")
                    .Respond(
                        "application/json",
                        JsonSerializer.Serialize(page)
                    );
            }

            var mockHttpClient = mockHttp.ToHttpClient();
            mockHttpClient.BaseAddress = new(testAddress);

            var apiClient = new OnspringClient("test", mockHttpClient);

            var appsResponses = apiClient
                .CreateRequest()
                .ToGetAllPages()
                .OfFields()
                .FromApp(_appIdWithFields)
                .SendAsync(o => o.PageSize = pageSize);

            var responsePages = new List<GetPagedFieldsResponse>();

            await foreach (var response in appsResponses)
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