using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class DeleteRecordsByIdsRequestBuilder : IDeleteRecordsByIdsRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; private set; }
        public IEnumerable<int> RecordIds { get; private set; }

        internal DeleteRecordsByIdsRequestBuilder(IOnspringClient client, int appId, IEnumerable<int> recordIds)
        {
            _client = client;
            AppId = appId;
            RecordIds = recordIds;
        }

        public async Task<ApiResponse> SendAsync()
        {
            return await _client.DeleteRecordsAsync(
                new DeleteRecordsRequest
                {
                    AppId = AppId,
                    RecordIds = RecordIds.ToList(),
                }
            );
        }
    }
}