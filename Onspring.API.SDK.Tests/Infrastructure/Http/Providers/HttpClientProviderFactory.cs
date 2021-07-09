using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.Infrastructure.Http.Providers
{
    [ExcludeFromCodeCoverage]
    internal static class HttpClientProviderFactory
    {
        public static IHttpClientProvider GetProvider(ClientType clientType)
        {
            return clientType switch
            {
                ClientType.External => new ExternalHttpClientProvider(),
                _ => new InternalHttpClientProvider(),
            };
        }
    }
}
