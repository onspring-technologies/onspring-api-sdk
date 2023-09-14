using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class OnspringRequest : IOnspringRequest
    {
        private readonly IOnspringClient _client;
        internal OnspringRequest(IOnspringClient client)
        {
            _client = client;
        }

        public IGetRecordsRequestBuilder ToGetRecords()
        {
            return new GetRecordsRequestBuilder(_client);
        }
    }
}