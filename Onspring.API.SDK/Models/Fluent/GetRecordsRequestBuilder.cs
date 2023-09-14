using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetRecordsRequestBuilder : IGetRecordsRequestBuilder
    {
        private readonly IOnspringClient _client;
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