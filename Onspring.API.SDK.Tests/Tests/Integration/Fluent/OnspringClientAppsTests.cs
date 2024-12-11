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

        [TestMethod]
        public async Task GetAllApps()
        {
            var testAddress = "https://localhost";

            var numberOfApps = 3;
            var pageSize = 50;
            var pages = TestDataFactory.GetPagesOfApps(numberOfApps, pageSize);

            var mockHttp = new MockHttpMessageHandler();

            foreach (var page in pages)
            {
                mockHttp
                    .When(HttpMethod.Get, $"{testAddress}/apps?PageNumber={page.PageNumber}&PageSize={pageSize}")
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
                .OfApps()
                .SendAsync();

            var responsePages = new List<GetPagedAppsResponse>();

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