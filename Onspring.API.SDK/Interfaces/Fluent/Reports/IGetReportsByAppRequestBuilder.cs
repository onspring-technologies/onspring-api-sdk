using System;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetReportsByAppRequestBuilder
    {
        int AppId { get; }
        int PageNumber { get; }
        int PageSize { get; }
        DataFormat Format { get; }
        IGetReportsByAppRequestBuilder ForPageNumber(int pageNumber);
        IGetReportsByAppRequestBuilder WithPageSize(int pageNumber);
        IGetReportsByAppRequestBuilder WithFormat(DataFormat format);
        Task<ApiResponse<GetReportsForAppResponse>> SendAsync();
        Task<ApiResponse<GetReportsForAppResponse>> SendAsync(Action<GetReportsByAppRequestBuilderOptions> options);
    }
}