using Onspring.API.SDK.Tests.TestServer;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

namespace Onspring.API.SDK.Tests.Infrastructure.Http.Providers
{
    [ExcludeFromCodeCoverage]
    internal class InternalHttpClientProvider : IHttpClientProvider
    {
        private static readonly Lazy<WebApiTestFixture> _apiFactory = new(() => new WebApiTestFixture());

        public HttpClient GetClient(string baseAddress)
        {
            return _apiFactory.Value.CreateClient();
        }
    }
}
