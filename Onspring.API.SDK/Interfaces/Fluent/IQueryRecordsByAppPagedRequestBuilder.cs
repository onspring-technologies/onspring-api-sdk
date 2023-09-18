using System.Collections.Generic;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IQueryRecordsByAppPagedRequestBuilder
    {
        IQueryRecordsByAppPagedRequestBuilder ForPageNumber(int pageNumber);
        IQueryRecordsByAppPagedRequestBuilder WithPageSize(int pageSize);
        IQueryRecordsByAppPagedRequestBuilder WithFieldIds(IEnumerable<int> fieldIds);
        IQueryRecordsByAppPagedRequestBuilder WithFormat(DataFormat dataFormat);

    }
}