using System.Collections.Generic;
using System.Threading.Tasks;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve fields by IDs.
    /// </summary>
    /// <inheritdoc/>
    public class GetFieldsByIdsRequestBuilder : IGetFieldsByIdsRequestBuilder
    {
        private readonly IOnspringClient _client;
        public IEnumerable<int> FieldIds { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetFieldsByIdsRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IOnspringClient"/> to use for the request.</param>
        /// <param name="fieldIds">The IDs of the fields to retrieve.</param>
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