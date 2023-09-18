using System.Runtime.CompilerServices;
using Onspring.API.SDK.Interfaces.Fluent;

[assembly: InternalsVisibleTo("Onspring.API.SDK.Tests")]
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