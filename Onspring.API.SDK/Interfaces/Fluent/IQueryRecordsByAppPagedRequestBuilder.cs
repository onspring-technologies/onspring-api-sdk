using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IQueryRecordsByAppPagedRequestBuilder
    {
        int AppId { get; }
        string Filter { get; }
        int PageNumber { get; }
        int PageSize { get; }
        IEnumerable<int> FieldIds { get; }
        DataFormat Format { get; }
        Task<ApiResponse<GetPagedRecordsResponse>> SendAsync();
        Task<ApiResponse<GetPagedRecordsResponse>> SendAsync(Action<QueryRecordsByAppPagedRequestBuilderOptions> options);
        IQueryRecordsByAppPagedRequestBuilder ForPageNumber(int pageNumber);
        IQueryRecordsByAppPagedRequestBuilder WithPageSize(int pageSize);
        IQueryRecordsByAppPagedRequestBuilder WithFieldIds(IEnumerable<int> fieldIds);
        IQueryRecordsByAppPagedRequestBuilder WithFormat(DataFormat dataFormat);

    }
}