using System;
using System.Threading.Tasks;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetFieldsByAppRequestBuilder : IGetFieldsByAppRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; private set; }
        public int PageNumber { get; private set; } = 1;
        public int PageSize { get; private set; } = 50;

        internal GetFieldsByAppRequestBuilder(IOnspringClient client, int appId)
        {
            _client = client;
            AppId = appId;
        }

        public IGetFieldsByAppRequestBuilder ForPage(int pageNumber)
        {
            PageNumber = pageNumber;
            return this;
        }

        public IGetFieldsByAppRequestBuilder WithPageSize(int pageSize)
        {
            PageSize = pageSize;
            return this;
        }

        public async Task<ApiResponse<GetPagedFieldsResponse>> SendAsync()
        {
            return await _client.GetFieldsForAppAsync(AppId, new PagingRequest(PageNumber, PageSize));
        }

        public async Task<ApiResponse<GetPagedFieldsResponse>> SendAsync(Action<GetFieldsByAppRequestBuilderOptions> options)
        {
            var opts = new GetFieldsByAppRequestBuilderOptions();
            options.Invoke(opts);
            return await _client.GetFieldsForAppAsync(AppId, new PagingRequest(opts.PageNumber, opts.PageSize));
        }
    }
}