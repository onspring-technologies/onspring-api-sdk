using System.Collections.Generic;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetAppsRequestBuilder : IGetAppsRequestBuilder
    {
        private readonly IOnspringClient _client;

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