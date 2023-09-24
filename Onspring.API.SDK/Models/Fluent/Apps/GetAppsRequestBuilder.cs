using System.Collections.Generic;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve apps.
    /// </summary>
    /// <inheritdoc/>
    public class GetAppsRequestBuilder : IGetAppsRequestBuilder
    {
        private readonly IOnspringClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAppsRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IOnspringClient"/> to use for the request.</param>
        internal GetAppsRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IGetPagedAppsRequestBuilder ForPage(int pageNumber)
        {
            return new GetPagedAppsRequestBuilder(_client, pageNumber);
        }

        public IGetAppsByIdsRequestBuilder WithIds(IEnumerable<int> appIds)
        {
            return new GetAppsByIdsRequestBuilder(_client, appIds);
        }

        public IGetAppByIdRequestBuilder WithId(int appId)
        {
            return new GetAppByIdRequestBuilder(_client, appId);
        }
    }
}