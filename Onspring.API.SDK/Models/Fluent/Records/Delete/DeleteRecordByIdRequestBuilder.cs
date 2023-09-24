using System.Threading.Tasks;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to delete a record from an app by ID.
    /// </summary>
    public class DeleteRecordByIdRequestBuilder : IDeleteRecordByIdRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; private set; }
        public int RecordId { get; private set; }

        /// <summary>
        /// Creates a new instance of the <see cref="DeleteRecordByIdRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IOnspringClient"/> used to send the request.</param>
        /// <param name="appId">The ID of the app from which to delete the record.</param>
        /// <param name="recordId">The ID of the record to delete.</param>
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