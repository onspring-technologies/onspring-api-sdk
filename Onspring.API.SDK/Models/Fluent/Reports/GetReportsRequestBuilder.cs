using Onspring.API.SDK.Interfaces.Fluent;
using System;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to get reports.
    /// </summary>
    /// <inheritdoc/>
    public class GetReportsRequestBuilder : IGetReportsRequestBuilder, IGetReportsByAppRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; private set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetReportsRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IOnspringClient"/> to use for the request.</param>
        internal GetReportsRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IGetReportsByAppRequestBuilder FromApp(int appId)
        {
            AppId = appId;
            return this;
        }

        public IGetReportsByAppRequestBuilder ForPage(int pageNumber)
        {
            PageNumber = pageNumber;
            return this;
        }

        public IGetReportsByAppRequestBuilder WithPageSize(int pageSize)
        {
            PageSize = pageSize;
            return this;
        }

        public async Task<ApiResponse<GetReportsForAppResponse>> SendAsync()
        {
            return await _client.GetReportsForAppAsync(AppId, new PagingRequest(PageNumber, PageSize));
        }

        public async Task<ApiResponse<GetReportsForAppResponse>> SendAsync(Action<GetReportsRequestBuilderOptions> options)
        {
            var opts = new GetReportsRequestBuilderOptions();
            options.Invoke(opts);
            return await _client.GetReportsForAppAsync(AppId, new PagingRequest(opts.PageNumber, opts.PageSize));
        }
    }
}