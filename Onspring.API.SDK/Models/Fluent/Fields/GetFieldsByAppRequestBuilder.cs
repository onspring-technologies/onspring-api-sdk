using Onspring.API.SDK.Interfaces.Fluent;
using System;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve fields by app.
    /// </summary>
    /// <inheritdoc/>
    public class GetFieldsByAppRequestBuilder : IGetFieldsByAppRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; private set; }
        public int PageNumber { get; private set; } = 1;
        public int PageSize { get; private set; } = 50;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetFieldsByAppRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IOnspringClient"/> to use for the request.</param>
        /// <param name="appId">The ID of the app to retrieve fields for.</param>
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