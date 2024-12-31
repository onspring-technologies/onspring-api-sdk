using Onspring.API.SDK.Interfaces.Fluent;
using System;
using System.Collections.Generic;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a request builder for getting all pages of fields.
    /// </summary>
    /// <inheritdoc/>
    public class GetAllFieldsPagesByAppRequestBuilder : IGetAllFieldsPagesByAppRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; private set; }
        public int PageSize { get; private set; } = 50;

        internal GetAllFieldsPagesByAppRequestBuilder(IOnspringClient client, int appId)
        {
            _client = client;
            AppId = appId;
        }

        public IGetAllFieldsPagesByAppRequestBuilder WithPageSize(int pageSize)
        {
            PageSize = pageSize;
            return this;
        }

        public async IAsyncEnumerable<ApiResponse<GetPagedFieldsResponse>> SendAsync()
        {
            await foreach (var response in _client.GetAllFieldsForAppAsync(AppId, PageSize))
            {
                yield return response;
            }
        }

        public async IAsyncEnumerable<ApiResponse<GetPagedFieldsResponse>> SendAsync(Action<GetAllFieldsPagesByAppRequestBuilderOptions> options)
        {
            var opts = new GetAllFieldsPagesByAppRequestBuilderOptions();
            options.Invoke(opts);

            await foreach (var response in _client.GetAllFieldsForAppAsync(AppId, opts.PageSize))
            {
                yield return response;
            }
        }
    }
}