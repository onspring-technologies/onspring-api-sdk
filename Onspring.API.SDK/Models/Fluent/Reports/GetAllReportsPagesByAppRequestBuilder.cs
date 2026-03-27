using Onspring.API.SDK.Interfaces.Fluent;
using System;
using System.Collections.Generic;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for requests to get all pages of reports.
    /// </summary>
    /// <inheritdoc/>
    public class GetAllReportsPagesByAppRequestBuilder : IGetAllReportsPagesByAppRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; }
        public int PageSize { get; private set; } = 50;

        internal GetAllReportsPagesByAppRequestBuilder(IOnspringClient client, int appId)
        {
            _client = client;
            AppId = appId;
        }

        public IGetAllReportsPagesByAppRequestBuilder WithPageSize(int pageSize)
        {
            PageSize = pageSize;
            return this;
        }

        public async IAsyncEnumerable<ApiResponse<GetReportsForAppResponse>> SendAsync()
        {
            await foreach (var response in _client.GetAllReportsForAppAsync(AppId, PageSize))
            {
                yield return response;
            }
        }

        public async IAsyncEnumerable<ApiResponse<GetReportsForAppResponse>> SendAsync(Action<GetAllReportsPagesByAppRequestBuilderOptions> options)
        {
            var opts = new GetAllReportsPagesByAppRequestBuilderOptions();
            options.Invoke(opts);

            await foreach (var response in _client.GetAllReportsForAppAsync(AppId, opts.PageSize))
            {
                yield return response;
            }
        }
    }
}