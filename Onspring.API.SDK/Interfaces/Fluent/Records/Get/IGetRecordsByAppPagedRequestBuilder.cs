using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetRecordsByAppPagedRequestBuilder
    {
        int AppId { get; }
        int PageNumber { get; }
        IEnumerable<int> FieldIds { get; }
        DataFormat Format { get; }
        int PageSize { get; }
        Task<ApiResponse<GetPagedRecordsResponse>> SendAsync();
        Task<ApiResponse<GetPagedRecordsResponse>> SendAsync(Action<GetRecordsByAppPagedRequestBuilderOptions> options);
        IGetRecordsByAppPagedRequestBuilder WithPageSize(int pageSize);
        IGetRecordsByAppPagedRequestBuilder WithFieldIds(IEnumerable<int> fieldIds);
        IGetRecordsByAppPagedRequestBuilder WithFormat(DataFormat dataFormat);
    }
}