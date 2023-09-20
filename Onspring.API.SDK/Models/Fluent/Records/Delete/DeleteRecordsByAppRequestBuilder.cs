using System.Collections.Generic;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class DeleteRecordsByAppRequestBuilder : IDeleteRecordsByAppRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; private set; }

        internal DeleteRecordsByAppRequestBuilder(IOnspringClient client, int appId)
        {
            _client = client;
            AppId = appId;
        }

        public IDeleteRecordByIdRequestBuilder WithId(int recordId)
        {
            return new DeleteRecordByIdRequestBuilder(_client, AppId, recordId);
        }

        public IDeleteRecordsByIdsRequestBuilder WithIds(IEnumerable<int> recordIds)
        {
            return new DeleteRecordsByIdsRequestBuilder(_client, AppId, recordIds);
        }
    }
}