using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a request builder for getting all pages of fields.
    /// </summary>
    /// <inheritdoc/>
    public class GetAllFieldsPagesRequestBuilder : IGetAllFieldsPagesRequestBuilder
    {
        private readonly IOnspringClient _client;

        internal GetAllFieldsPagesRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IGetAllFieldsPagesByAppRequestBuilder FromApp(int appId)
        {
            return new GetAllFieldsPagesByAppRequestBuilder(_client, appId);
        }
    }
}