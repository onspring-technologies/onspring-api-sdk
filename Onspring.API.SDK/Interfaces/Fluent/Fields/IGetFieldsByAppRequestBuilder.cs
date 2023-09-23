using System;
using System.Threading.Tasks;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetFieldsByAppRequestBuilder
    {
        int AppId { get; }
        int PageNumber { get; }
        int PageSize { get; }
        IGetFieldsByAppRequestBuilder ForPageNumber(int pageNumber);
        IGetFieldsByAppRequestBuilder WithPageSize(int pageSize);
        Task<ApiResponse<GetPagedFieldsResponse>> SendAsync();
        Task<ApiResponse<GetPagedFieldsResponse>> SendAsync(Action<GetFieldsByAppRequestBuilderOptions> options);
    }
}