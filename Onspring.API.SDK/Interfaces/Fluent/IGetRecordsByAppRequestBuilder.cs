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
        Task<ApiResponse<GetPagedRecordsResponse>> SendAsync();
        Task<ApiResponse<GetPagedRecordsResponse>> SendAsync(Action<GetRecordsByAppRequestBuilderOptions> options);
        IGetRecordsByAppRequestBuilder ForPage(int pageNumber);
        IGetRecordsByAppRequestBuilder WithPageSize(int pageSize);
        IGetRecordsByAppRequestBuilder WithFieldIds(IEnumerable<int> fieldIds);
        IGetRecordsByAppRequestBuilder WithFormat(DataFormat dataFormat);
    }
}