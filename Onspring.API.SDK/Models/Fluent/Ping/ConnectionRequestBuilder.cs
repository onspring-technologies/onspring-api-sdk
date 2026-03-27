using Onspring.API.SDK.Interfaces.Fluent;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <inheritdoc/>
    public class ConnectionRequestBuilder : IConnectionRequestBuilder
    {
        private readonly IOnspringClient _client;

        internal ConnectionRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public async Task<bool> SendAsync()
        {
            return await _client.CanConnectAsync();
        }
    }
}