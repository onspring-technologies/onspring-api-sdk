using Onspring.API.SDK.Tests.Infrastructure.Http.Providers;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

namespace Onspring.API.SDK.Tests.Infrastructure.Http
{
    [ExcludeFromCodeCoverage]
    internal static class HttpClientFactory
    {
        private static readonly ConcurrentDictionary<string, HttpClient> _clientCache = new();

        public static HttpClient GetHttpClient(TestConfiguration testConfiguration)
        {
            var cacheKey = GetCacheKey(testConfiguration);
            return _clientCache.GetOrAdd(cacheKey, (key) =>
            {
                var provider = HttpClientProviderFactory.GetProvider(testConfiguration.ClientType);
                var httpClient = provider.GetClient(testConfiguration.BaseAddress);
                return httpClient;
            });
        }

        private static string GetCacheKey(TestConfiguration testConfiguration)
        {
            return $"{testConfiguration.ClientType}-{testConfiguration.BaseAddress}-{testConfiguration.ApiKey}";
        }
    }
}
