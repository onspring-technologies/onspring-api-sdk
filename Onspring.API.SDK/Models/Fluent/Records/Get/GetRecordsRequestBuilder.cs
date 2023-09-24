using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve records.
    /// </summary>
    /// <inheritdoc/>
    public class GetRecordsRequestBuilder : IGetRecordsRequestBuilder
    {
        private readonly IOnspringClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRecordsRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The Onspring client to use for making API requests.</param>
        internal GetRecordsRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IGetRecordsByAppRequestBuilder FromApp(int appId)
        {
            return new GetRecordsByAppRequestBuilder(_client, appId);
        }
    }
}