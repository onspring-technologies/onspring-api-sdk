using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to delete records.
    /// </summary>
    /// <inheritdoc/>
    public class DeleteRecordsRequestBuilder : IDeleteRecordsRequestBuilder
    {
        private readonly IOnspringClient _client;

        /// <summary>
        /// Creates a new instance of the <see cref="DeleteRecordsRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IOnspringClient"/> used to send the request.</param>
        internal DeleteRecordsRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IDeleteRecordsByAppRequestBuilder FromApp(int appId)
        {
            return new DeleteRecordsByAppRequestBuilder(_client, appId);
        }
    }
}