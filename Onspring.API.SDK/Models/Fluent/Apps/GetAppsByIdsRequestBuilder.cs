using Onspring.API.SDK.Interfaces.Fluent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve apps by IDs
    /// </summary>
    /// <inheritdoc/>
    public class GetAppsByIdsRequestBuilder : IGetAppsByIdsRequestBuilder
    {
        private readonly IOnspringClient _client;
        public IEnumerable<int> AppIds { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAppsByIdsRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IOnspringClient"/> to use for the request.</param>
        /// <param name="appIds">The IDs of the apps to retrieve.</param>
        internal GetAppsByIdsRequestBuilder(IOnspringClient client, IEnumerable<int> appIds)
        {
            _client = client;
            AppIds = appIds;
        }

        public async Task<ApiResponse<GetAppsResponse>> SendAsync()
        {
            return await _client.GetAppsAsync(AppIds);
        }
    }
}