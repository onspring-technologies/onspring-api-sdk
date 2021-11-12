using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

namespace Onspring.API.SDK.Tests.Infrastructure.Http.Providers
{
    [ExcludeFromCodeCoverage]
    internal class ExternalHttpClientProvider : IHttpClientProvider
    {
        public HttpClient GetClient(string baseAddress)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress),
            };

            return httpClient;
        }
    }
}
