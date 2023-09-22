using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class DeleteRecordsRequestBuilder : IDeleteRecordsRequestBuilder
    {
        private readonly IOnspringClient _client;

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