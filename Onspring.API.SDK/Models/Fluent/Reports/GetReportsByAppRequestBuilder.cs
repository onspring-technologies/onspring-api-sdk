using System;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetReportsByAppRequestBuilder : IGetReportsByAppRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; private set; }
        public int PageNumber { get; private set; } = 1;
        public int PageSize { get; private set; } = 50;

        internal GetReportsByAppRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IGetReportsByAppRequestBuilder ForPageNumber(int pageNumber)
        {
            PageNumber = pageNumber;
            return this;
        }

        public IGetReportsByAppRequestBuilder WithPageSize(int pageNumber)
        {
            PageNumber = pageNumber;
            return this;
        }

        public async Task<ApiResponse<GetReportsForAppResponse>> SendAsync()
        {
            return await _client.GetReportsForAppAsync(AppId, new PagingRequest(PageNumber, PageSize));
        }

        public async Task<ApiResponse<GetReportsForAppResponse>> SendAsync(Action<GetReportsByAppRequestBuilderOptions> options)
        {
            var opts = new GetReportsByAppRequestBuilderOptions();
            options.Invoke(opts);
            return await _client.GetReportsForAppAsync(AppId, new PagingRequest(opts.PageNumber, opts.PageSize));
        }

    }
}