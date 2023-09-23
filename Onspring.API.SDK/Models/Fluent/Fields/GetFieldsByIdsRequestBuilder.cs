using System.Collections.Generic;
using System.Threading.Tasks;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetFieldsByIdsRequestBuilder : IGetFieldsByIdsRequestBuilder
    {
        private readonly IOnspringClient _client;
        public IEnumerable<int> FieldIds { get; private set; }

        internal GetFieldsByIdsRequestBuilder(IOnspringClient client, IEnumerable<int> fieldIds)
        {
            _client = client;
            FieldIds = fieldIds;
        }

        public async Task<ApiResponse<GetFieldsResponse>> SendAsync()
        {
            return await _client.GetFieldsAsync(FieldIds);
        }
    }
}