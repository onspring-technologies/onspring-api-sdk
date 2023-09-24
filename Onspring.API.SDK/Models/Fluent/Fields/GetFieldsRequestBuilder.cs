using Onspring.API.SDK.Interfaces.Fluent;
using System.Collections.Generic;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve fields.
    /// </summary>
    /// <inheritdoc/>
    public class GetFieldsRequestBuilder : IGetFieldsRequestBuilder
    {
        private readonly IOnspringClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetFieldsRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IOnspringClient"/> to use for the request.</param>
        internal GetFieldsRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IGetFieldsByAppRequestBuilder FromApp(int appId)
        {
            return new GetFieldsByAppRequestBuilder(_client, appId);
        }

        public IGetFieldByIdRequestBuilder WithId(int fieldId)
        {
            return new GetFieldByIdRequestBuilder(_client, fieldId);
        }

        public IGetFieldsByIdsRequestBuilder WithIds(IEnumerable<int> fieldIds)
        {
            return new GetFieldsByIdsRequestBuilder(_client, fieldIds);
        }
    }
}