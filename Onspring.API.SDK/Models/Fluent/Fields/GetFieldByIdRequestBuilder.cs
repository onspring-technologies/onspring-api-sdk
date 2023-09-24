using Onspring.API.SDK.Interfaces.Fluent;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve fields by id.
    /// </summary>
    /// <inheritdoc/>
    public class GetFieldByIdRequestBuilder : IGetFieldByIdRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int FieldId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetFieldByIdRequestBuilder"/> class.
        /// </summary>
        internal GetFieldByIdRequestBuilder(IOnspringClient client, int fieldId)
        {
            _client = client;
            FieldId = fieldId;
        }

        public async Task<ApiResponse<Field>> SendAsync()
        {
            return await _client.GetFieldAsync(FieldId);
        }
    }
}