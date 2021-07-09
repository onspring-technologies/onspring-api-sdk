using System.Net.Http;

namespace Onspring.API.SDK.Tests.Infrastructure.Http.Providers
{
    internal interface IHttpClientProvider
    {
        HttpClient GetClient(string baseAddress);
    }
}
