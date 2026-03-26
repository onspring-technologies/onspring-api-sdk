using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Http;
using Onspring.API.SDK.Json;
using Onspring.API.SDK.Tests.Infrastructure;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using HttpClientFactory = Onspring.API.SDK.Tests.Infrastructure.Http.HttpClientFactory;

namespace Onspring.API.SDK.Tests.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ApiResponseFactoryTests
    {
        private static OnspringClient _apiClient;
        private static HttpClient _httpClient;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var testConfiguration = TestConfiguration.LoadFromContext(testContext);
            _httpClient = HttpClientFactory.GetHttpClient(testConfiguration);
            _apiClient = new OnspringClient(testConfiguration.ApiKey, _httpClient);
        }

        [TestMethod]
        public async Task GetApiResponse_WithNonJsonUnauthorizedResponse_DoesNotThrowJsonReaderException()
        {
            var requestUri = new Uri(_httpClient.BaseAddress, "errorresponse/non-json-unauthorized");
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            var httpResponse = await _httpClient.SendAsync(request);

            var jsonSerializer = JsonSerializerFactory.GetDefaultSerializer();

            await ApiResponseFactory.GetApiResponseAsync(httpResponse, jsonSerializer);
        }

        [TestMethod]
        public async Task GetApiResponse_WithNonJsonForbiddenResponse_DoesNotThrowJsonReaderException()
        {
            var requestUri = new Uri(_httpClient.BaseAddress, "errorresponse/non-json-forbidden");
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            var httpResponse = await _httpClient.SendAsync(request);

            var jsonSerializer = JsonSerializerFactory.GetDefaultSerializer();

            await ApiResponseFactory.GetApiResponseAsync(httpResponse, jsonSerializer);
        }

        [TestMethod]
        public async Task GetApiResponse_WithNonJsonNotFoundResponse_DoesNotThrowJsonReaderException()
        {
            var requestUri = new Uri(_httpClient.BaseAddress, "errorresponse/non-json-not-found");
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            var httpResponse = await _httpClient.SendAsync(request);
            var jsonSerializer = JsonSerializerFactory.GetDefaultSerializer();

            await ApiResponseFactory.GetApiResponseAsync(httpResponse, jsonSerializer);
        }
    }
}
