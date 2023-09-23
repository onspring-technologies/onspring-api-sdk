using System.Collections.Generic;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetFieldsRequestBuilder : IGetFieldsRequestBuilder
    {
        private readonly IOnspringClient _client;

        internal GetFieldsRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IGetFieldsByAppRequestBuilder FromApp(int appId)
        {
            return new GetFieldsByAppRequestBuilder(_client, appId);
        }

        public IGetFieldByIdRequestBuilder WithId(int fieldId)
        {
            return new GetFieldByIdRequestBuilder(_client, fieldId);
        }

        public IGetFieldsByIdsRequestBuilder WithIds(IEnumerable<int> fieldIds)
        {
            return new GetFieldsByIdsRequestBuilder(_client, fieldIds);
        }
    }
}