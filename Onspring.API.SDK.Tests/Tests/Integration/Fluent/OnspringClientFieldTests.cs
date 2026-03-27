using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Tests.Infrastructure;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using Onspring.API.SDK.Tests.Infrastructure.Http;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
    }
}