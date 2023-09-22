using System;
using System.Collections.Generic;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetRecordsByAppRequestBuilder : IGetRecordsByAppRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; private set; }

        internal GetRecordsByAppRequestBuilder(IOnspringClient client, int appId)
        {
            _client = client;
            AppId = appId;
        }

        public IGetRecordsByAppPagedRequestBuilder ForPage(int pageNumber)
        {
            return new GetRecordsByAppPagedRequestBuilder(_client, AppId, pageNumber);
        }

        public IGetRecordByIdRequestBuilder WithId(int recordId)
        {
            return new GetRecordByIdRequestBuilder(_client, AppId, recordId);
        }

        public IGetRecordsByIdsRequestBuilder WithIds(IEnumerable<int> recordIds)
        {
            return new GetRecordsByIdsRequestBuilder(_client, AppId, recordIds);
        }

        public IQueryRecordsByAppPagedRequestBuilder WithFilter(string filter)
        {
            return new QueryRecordsByAppPagedRequestBuilder(_client, AppId, filter);
        }

        public IQueryRecordsByAppPagedRequestBuilder WithFilter(Action<Filter> filter)
        {
            var queryFilter = new Filter();
            filter.Invoke(queryFilter);
            return new QueryRecordsByAppPagedRequestBuilder(_client, AppId, queryFilter.ToString());
        }
    }
}