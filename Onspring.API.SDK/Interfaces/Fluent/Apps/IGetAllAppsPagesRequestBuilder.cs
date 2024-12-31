using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System;
using System.Collections.Generic;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetAllAppsPagesRequestBuilder
    {
        int PageSize { get; }

        IGetAllAppsPagesRequestBuilder WithPageSize(int pageSize);

        IAsyncEnumerable<ApiResponse<GetPagedAppsResponse>> SendAsync();

        IAsyncEnumerable<ApiResponse<GetPagedAppsResponse>> SendAsync(Action<GetAllAppsPagesRequestBuilderOptions> options);
    }
}