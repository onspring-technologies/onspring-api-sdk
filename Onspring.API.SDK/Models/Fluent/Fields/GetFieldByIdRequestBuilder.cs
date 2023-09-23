using System.Threading.Tasks;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetFieldByIdRequestBuilder : IGetFieldByIdRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int FieldId { get; private set; }

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