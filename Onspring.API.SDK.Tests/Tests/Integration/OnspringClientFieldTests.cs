using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Tests.Infrastructure;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using Onspring.API.SDK.Tests.Infrastructure.Http;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
    }
}