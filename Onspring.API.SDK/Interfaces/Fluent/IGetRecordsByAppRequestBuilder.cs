using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetRecordsByAppRequestBuilder
    {
        IGetRecordsByAppPagedRequestBuilder ForPage(int pageNumber);
        IGetRecordByIdRequestBuilder WithId(int recordId);
        IGetRecordsByIdsRequestBuilder WithIds(IEnumerable<int> recordIds);
        IQueryRecordsByAppPagedRequestBuilder WithFilter(string filter);
        IQueryRecordsByAppPagedRequestBuilder WithFilter(Action<Filter> filter);
    }
}