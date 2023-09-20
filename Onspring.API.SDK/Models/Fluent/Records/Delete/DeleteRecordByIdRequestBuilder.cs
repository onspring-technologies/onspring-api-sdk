using System.Threading.Tasks;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class DeleteRecordByIdRequestBuilder : IDeleteRecordByIdRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; private set; }
        public int RecordId { get; private set; }

        internal DeleteRecordByIdRequestBuilder(IOnspringClient client, int appId, int recordId)
        {
            _client = client;
            AppId = appId;
            RecordId = recordId;
        }

        public async Task<ApiResponse> SendAsync()
        {
            return await _client.DeleteRecordAsync(AppId, RecordId);
        }
    }
}