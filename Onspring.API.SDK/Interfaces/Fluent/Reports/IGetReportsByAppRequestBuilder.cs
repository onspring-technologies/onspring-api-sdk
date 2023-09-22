using System;
using System.Threading.Tasks;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetReportsByAppRequestBuilder
    {
        int AppId { get; }
        int PageNumber { get; }
        int PageSize { get; }
        IGetReportsByAppRequestBuilder ForPageNumber(int pageNumber);
        IGetReportsByAppRequestBuilder WithPageSize(int pageNumber);
        Task<ApiResponse<GetReportsForAppResponse>> SendAsync();
        Task<ApiResponse<GetReportsForAppResponse>> SendAsync(Action<GetReportsRequestBuilderOptions> options);
    }
}