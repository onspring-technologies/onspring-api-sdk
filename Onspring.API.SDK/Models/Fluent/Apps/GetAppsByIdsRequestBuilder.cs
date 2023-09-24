using System.Collections.Generic;
using System.Threading.Tasks;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetAppsByIdsRequestBuilder : IGetAppsByIdsRequestBuilder
    {
        private readonly IOnspringClient _client;
        public IEnumerable<int> AppIds { get; private set; }

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