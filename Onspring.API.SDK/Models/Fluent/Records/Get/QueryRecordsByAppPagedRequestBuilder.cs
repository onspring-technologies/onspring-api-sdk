using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class QueryRecordsByAppPagedRequestBuilder : IQueryRecordsByAppPagedRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; private set; }
        public string Filter { get; private set; }
        public int PageNumber { get; private set; } = 1;
        public int PageSize { get; private set; } = 50;
        public IEnumerable<int> FieldIds { get; private set; } = Enumerable.Empty<int>();
        public DataFormat Format { get; private set; } = DataFormat.Raw;

        internal QueryRecordsByAppPagedRequestBuilder(IOnspringClient client, int appId, string filter)
        {
            _client = client;
            AppId = appId;
            Filter = filter;
        }

        public IQueryRecordsByAppPagedRequestBuilder ForPage(int pageNumber)
        {
            PageNumber = pageNumber;
            return this;
        }

        public IQueryRecordsByAppPagedRequestBuilder WithPageSize(int pageSize)
        {
            PageSize = pageSize;
            return this;
        }

        public IQueryRecordsByAppPagedRequestBuilder WithFieldIds(IEnumerable<int> fieldIds)
        {
            FieldIds = fieldIds;
            return this;
        }

        public IQueryRecordsByAppPagedRequestBuilder WithFormat(DataFormat dataFormat)
        {
            Format = dataFormat;
            return this;
        }

        public async Task<ApiResponse<GetPagedRecordsResponse>> SendAsync()
        {
            return await _client.QueryRecordsAsync(
                new QueryRecordsRequest()
                {
                    Filter = Filter,
                    FieldIds = FieldIds.ToList(),
                    DataFormat = Format,
                },
                new PagingRequest()
                {
                    PageNumber = PageNumber,
                    PageSize = PageSize
                }
            );
        }

        public async Task<ApiResponse<GetPagedRecordsResponse>> SendAsync(Action<QueryRecordsByAppPagedRequestBuilderOptions> options)
        {
            var opts = new QueryRecordsByAppPagedRequestBuilderOptions();
            options.Invoke(opts);
            return await _client.QueryRecordsAsync(
                new QueryRecordsRequest()
                {
                    Filter = Filter,
                    FieldIds = opts.FieldIds.ToList(),
                    DataFormat = opts.Format,
                },
                new PagingRequest()
                {
                    PageNumber = opts.PageNumber,
                    PageSize = opts.PageSize
                }
            );
        }
    }
}