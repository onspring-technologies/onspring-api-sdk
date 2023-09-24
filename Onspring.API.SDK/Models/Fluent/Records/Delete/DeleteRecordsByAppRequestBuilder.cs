using Onspring.API.SDK.Interfaces.Fluent;
using System.Collections.Generic;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to delete records from an app.
    /// </summary>
    /// <inheritdoc/>
    public class DeleteRecordsByAppRequestBuilder : IDeleteRecordsByAppRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; private set; }

        /// <summary>
        /// Creates a new instance of the <see cref="DeleteRecordsByAppRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IOnspringClient"/> used to send the request.</param>
        /// <param name="appId">The ID of the app from which to delete records.</param>
        internal DeleteRecordsByAppRequestBuilder(IOnspringClient client, int appId)
        {
            _client = client;
            AppId = appId;
        }

        public IDeleteRecordByIdRequestBuilder WithId(int recordId)
        {
            return new DeleteRecordByIdRequestBuilder(_client, AppId, recordId);
        }

        public IDeleteRecordsByIdsRequestBuilder WithIds(IEnumerable<int> recordIds)
        {
            return new DeleteRecordsByIdsRequestBuilder(_client, AppId, recordIds);
        }
    }
}