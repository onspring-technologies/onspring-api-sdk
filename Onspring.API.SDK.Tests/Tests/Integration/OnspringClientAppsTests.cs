using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Tests.Infrastructure;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using Onspring.API.SDK.Tests.Infrastructure.Http;
using RichardSzalay.MockHttp;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
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

        [TestMethod]
        public async Task GetAllAppsAsync_WhenUsingDefaultPageSize_ReturnsAllApps()
        {
            var testAddress = "https://localhost";

            var mockHttp = new MockHttpMessageHandler();

            var pageOneResponse = new GetPagedAppsResponse
            {
                PageNumber = 1,
                TotalPages = 3,
                TotalRecords = 3,
                Items =
                [
                    new()
                    {
                        Href = testAddress,
                        Id = 1,
                        Name = "Test App",
                    },
                ]
            };

            var pageTwoResponse = new GetPagedAppsResponse
            {
                PageNumber = 2,
                TotalPages = 3,
                TotalRecords = 3,
                Items =
                [
                    new()
                    {
                        Href = testAddress,
                        Id = 2,
                        Name = "Test App",
                    },
                ]
            };

            var pageThreeResponse = new GetPagedAppsResponse
            {
                PageNumber = 3,
                TotalPages = 3,
                TotalRecords = 3,
                Items =
                [
                    new()
                    {
                        Href = testAddress,
                        Id = 3,
                        Name = "Test App",
                    },
                ]
            };

            mockHttp
                .When(HttpMethod.Get, $"{testAddress}/apps?PageNumber=1&PageSize=50")
                .Respond(
                    "application/json",
                    JsonSerializer.Serialize(pageOneResponse)
                );

            mockHttp
                .When(HttpMethod.Get, $"{testAddress}/apps?PageNumber=2&PageSize=50")
                .Respond(
                    "application/json",
                    JsonSerializer.Serialize(pageTwoResponse)
                );

            mockHttp
                .When(HttpMethod.Get, $"{testAddress}/apps?PageNumber=3&PageSize=50")
                .Respond(
                    "application/json",
                    JsonSerializer.Serialize(pageThreeResponse)
                );

            var mockHttpClient = mockHttp.ToHttpClient();
            mockHttpClient.BaseAddress = new(testAddress);

            var apiClient = new OnspringClient("test", mockHttpClient);

            var appsResponse = apiClient.GetAllAppsAsync();

            var responsePages = new List<GetPagedAppsResponse>();

            await foreach (var response in appsResponse)
            {
                AssertHelper.AssertSuccess(response);
                responsePages.Add(response.Value);
            }

            Assert.AreEqual(3, responsePages.Count);

            Assert.AreEqual(pageOneResponse.PageNumber, responsePages[0].PageNumber);
            Assert.AreEqual(pageOneResponse.Items.Count, responsePages[0].Items.Count);
            Assert.AreEqual(pageOneResponse.Items[0].Id, responsePages[0].Items[0].Id);

            Assert.AreEqual(pageTwoResponse.PageNumber, responsePages[1].PageNumber);
            Assert.AreEqual(pageTwoResponse.Items.Count, responsePages[1].Items.Count);
            Assert.AreEqual(pageTwoResponse.Items[0].Id, responsePages[1].Items[0].Id);

            Assert.AreEqual(pageThreeResponse.PageNumber, responsePages[2].PageNumber);
            Assert.AreEqual(pageThreeResponse.Items.Count, responsePages[2].Items.Count);
            Assert.AreEqual(pageThreeResponse.Items[0].Id, responsePages[2].Items[0].Id);
        }

        [TestMethod]
        public async Task GetAllAppsAsync_WhenUsingSpecificPageSize_ReturnsAllApps()
        {
            var testAddress = "https://localhost";

            var mockHttp = new MockHttpMessageHandler();

            var pageOneResponse = new GetPagedAppsResponse
            {
                PageNumber = 1,
                TotalPages = 3,
                TotalRecords = 3,
                Items =
                [
                    new()
                    {
                        Href = testAddress,
                        Id = 1,
                        Name = "Test App",
                    },
                ]
            };

            var pageTwoResponse = new GetPagedAppsResponse
            {
                PageNumber = 2,
                TotalPages = 3,
                TotalRecords = 3,
                Items =
                [
                    new()
                    {
                        Href = testAddress,
                        Id = 2,
                        Name = "Test App",
                    },
                ]
            };

            var pageThreeResponse = new GetPagedAppsResponse
            {
                PageNumber = 3,
                TotalPages = 3,
                TotalRecords = 3,
                Items =
                [
                    new()
                    {
                        Href = testAddress,
                        Id = 3,
                        Name = "Test App",
                    },
                ]
            };

            mockHttp
                .When(HttpMethod.Get, $"{testAddress}/apps?PageNumber=1&PageSize=1")
                .Respond(
                    "application/json",
                    JsonSerializer.Serialize(pageOneResponse)
                );

            mockHttp
                .When(HttpMethod.Get, $"{testAddress}/apps?PageNumber=2&PageSize=1")
                .Respond(
                    "application/json",
                    JsonSerializer.Serialize(pageTwoResponse)
                );

            mockHttp
                .When(HttpMethod.Get, $"{testAddress}/apps?PageNumber=3&PageSize=1")
                .Respond(
                    "application/json",
                    JsonSerializer.Serialize(pageThreeResponse)
                );

            var mockHttpClient = mockHttp.ToHttpClient();
            mockHttpClient.BaseAddress = new(testAddress);

            var apiClient = new OnspringClient("test", mockHttpClient);

            var appsResponse = apiClient.GetAllAppsAsync(1);

            var responsePages = new List<GetPagedAppsResponse>();

            await foreach (var response in appsResponse)
            {
                AssertHelper.AssertSuccess(response);
                responsePages.Add(response.Value);
            }

            Assert.AreEqual(3, responsePages.Count);

            Assert.AreEqual(pageOneResponse.PageNumber, responsePages[0].PageNumber);
            Assert.AreEqual(pageOneResponse.Items.Count, responsePages[0].Items.Count);
            Assert.AreEqual(pageOneResponse.Items[0].Id, responsePages[0].Items[0].Id);

            Assert.AreEqual(pageTwoResponse.PageNumber, responsePages[1].PageNumber);
            Assert.AreEqual(pageTwoResponse.Items.Count, responsePages[1].Items.Count);
            Assert.AreEqual(pageTwoResponse.Items[0].Id, responsePages[1].Items[0].Id);

            Assert.AreEqual(pageThreeResponse.PageNumber, responsePages[2].PageNumber);
            Assert.AreEqual(pageThreeResponse.Items.Count, responsePages[2].Items.Count);
            Assert.AreEqual(pageThreeResponse.Items[0].Id, responsePages[2].Items[0].Id);
        }
    }
}