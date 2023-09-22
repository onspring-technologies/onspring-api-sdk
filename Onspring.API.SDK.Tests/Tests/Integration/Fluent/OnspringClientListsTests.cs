using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Tests.Infrastructure;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using Onspring.API.SDK.Tests.Infrastructure.Http;

namespace Onspring.API.SDK.Tests.Tests.Integration.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OnspringClientListsTests
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
        public async Task AddListValue()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToSaveListValue()
                .InList(1)
                .WithId(null)
                .WithName("Test")
                .WithNumericValue(0)
                .WithColor("#db3e3e")
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
            Assert.IsInstanceOfType<Guid>(apiResponse.Value.Id);
        }

        [TestMethod]
        public async Task UpdateListValue()
        {
            var testId = Guid.NewGuid();

            var apiResponse = await _apiClient
                .CreateRequest()
                .ToSaveListValue()
                .InList(1)
                .WithId(testId)
                .WithName("Test")
                .WithNumericValue(0)
                .WithColor("#db3e3e")
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
            Assert.AreEqual(testId, apiResponse.Value.Id);
        }
    }
}