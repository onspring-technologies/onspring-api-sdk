using System;
using System.Collections.Generic;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetRecordsByAppRequestBuilder
    {
        int AppId { get; }
        IGetRecordsByAppPagedRequestBuilder ForPage(int pageNumber);
        IGetRecordByIdRequestBuilder WithId(int recordId);
        IGetRecordsByIdsRequestBuilder WithIds(IEnumerable<int> recordIds);
        IQueryRecordsByAppPagedRequestBuilder WithFilter(string filter);
        IQueryRecordsByAppPagedRequestBuilder WithFilter(Action<Filter> filter);
    }
}