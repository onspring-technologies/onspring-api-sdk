using Onspring.API.SDK.Models;
using System.Collections.Generic;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetAllAppsPagesRequestBuilder
    {
        int PageSize { get; }

        IGetAllAppsPagesRequestBuilder WithPageSize(int pageSize);

        IAsyncEnumerable<ApiResponse<GetPagedAppsResponse>> SendAsync();
    }
}