using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Tests.Infrastructure;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using Onspring.API.SDK.Tests.Infrastructure.Http;

namespace Onspring.API.SDK.Tests.Tests.Integration.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OnspringClientFilesTests
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
        public async Task GetFile()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetFile()
                .FromRecord(1)
                .InField(1)
                .WithId(1)
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
        }
    }
}