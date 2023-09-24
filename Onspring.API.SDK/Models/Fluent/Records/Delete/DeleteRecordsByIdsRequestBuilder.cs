using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to delete records from an app by IDs.
    /// </summary>
    public class DeleteRecordsByIdsRequestBuilder : IDeleteRecordsByIdsRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; private set; }
        public IEnumerable<int> RecordIds { get; private set; }

        /// <summary>
        /// Creates a new instance of the <see cref="DeleteRecordsByIdsRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IOnspringClient"/> used to send the request.</param>
        /// <param name="appId">The ID of the app from which to delete records.</param>
        /// <param name="recordIds">The IDs of the records to delete.</param>
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