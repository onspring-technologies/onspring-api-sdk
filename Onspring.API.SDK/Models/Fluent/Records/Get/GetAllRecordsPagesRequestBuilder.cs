using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetAllRecordsPagesRequestBuilder : IGetAllRecordsPagesRequestBuilder
    {
        private readonly IOnspringClient _client;

        internal GetAllRecordsPagesRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IGetAllRecordsPagesByAppRequestBuilder FromApp(int appId)
        {
            return new GetAllRecordsPagesByAppRequestBuilder(_client, appId);
        }
    }
}
