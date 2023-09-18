using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public partial class GetRecordsByAppPagedRequestBuilder : IGetRecordsByAppPagedRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; private set; }
        public int PageNumber { get; private set; }
        public IEnumerable<int> FieldIds { get; private set; } = Enumerable.Empty<int>();
        public DataFormat Format { get; private set; } = DataFormat.Raw;
        public int PageSize { get; private set; } = 50;

        internal GetRecordsByAppPagedRequestBuilder(IOnspringClient client, int appId, int pageNumber)
        {
            _client = client;
            AppId = appId;
            PageNumber = pageNumber;
        }

        public IGetRecordsByAppPagedRequestBuilder WithPageSize(int pageSize)
        {
            PageSize = pageSize;
            return this;
        }

        public IGetRecordsByAppPagedRequestBuilder WithFieldIds(IEnumerable<int> fieldIds)
        {
            FieldIds = fieldIds;
            return this;
        }

        public IGetRecordsByAppPagedRequestBuilder WithFormat(DataFormat dataFormat)
        {
            Format = dataFormat;
            return this;
        }

        async public Task<ApiResponse<GetPagedRecordsResponse>> SendAsync()
        {
            return await _client.GetRecordsForAppAsync(
                new GetRecordsByAppRequest
                {
                    AppId = AppId,
                    FieldIds = FieldIds.ToList(),
                    DataFormat = Format,
                    PagingRequest = new PagingRequest
                    {
                        PageNumber = PageNumber,
                        PageSize = PageSize
                    }
                }
            );
        }

        async public Task<ApiResponse<GetPagedRecordsResponse>> SendAsync(Action<GetRecordsByAppPagedRequestBuilderOptions> options)
        {
            var opts = new GetRecordsByAppPagedRequestBuilderOptions();
            options.Invoke(opts);
            return await _client.GetRecordsForAppAsync(
                new GetRecordsByAppRequest
                {
                    AppId = AppId,
                    FieldIds = opts.FieldIds.ToList(),
                    DataFormat = opts.Format,
                    PagingRequest = new PagingRequest
                    {
                        PageNumber = PageNumber,
                        PageSize = opts.PageSize,
                    }
                }
            );
        }
    }
}