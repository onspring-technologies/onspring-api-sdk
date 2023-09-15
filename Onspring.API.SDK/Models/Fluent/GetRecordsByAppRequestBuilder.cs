using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public partial class GetRecordsByAppRequestBuilder : IGetRecordsByAppRequestBuilder
    {
        private readonly IOnspringClient _client;
        private readonly int _appId;
        private IEnumerable<int> _fieldIds = Enumerable.Empty<int>();
        private DataFormat _dataFormat = DataFormat.Raw;
        private int _pageNumber = 1;
        private int _pageSize = 50;

        internal GetRecordsByAppRequestBuilder(IOnspringClient client, int appId)
        {
            _client = client;
            _appId = appId;
        }

        public IGetRecordsByAppRequestBuilder ForPage(int pageNumber)
        {
            _pageNumber = pageNumber;
            return this;
        }

        public IGetRecordsByAppRequestBuilder WithPageSize(int pageSize)
        {
            _pageSize = pageSize;
            return this;
        }

        public IGetRecordsByAppRequestBuilder WithFieldIds(IEnumerable<int> fieldIds)
        {
            _fieldIds = fieldIds;
            return this;
        }

        public IGetRecordsByAppRequestBuilder WithFormat(DataFormat dataFormat)
        {
            _dataFormat = dataFormat;
            return this;
        }

        public IGetRecordByIdRequestBuilder WithId(int recordId)
        {
            return new GetRecordByIdRequestBuilder(_client, _appId, recordId);
        }

        public IGetRecordsByIdsRequestBuilder WithIds(IEnumerable<int> recordIds)
        {
            return new GetRecordsByIdsRequestBuilder(_client, _appId, recordIds);
        }

        async public Task<ApiResponse<GetPagedRecordsResponse>> SendAsync()
        {
            return await _client.GetRecordsForAppAsync(
                new GetRecordsByAppRequest
                {
                    AppId = _appId,
                    FieldIds = _fieldIds.ToList(),
                    DataFormat = _dataFormat,
                    PagingRequest = new PagingRequest
                    {
                        PageNumber = _pageNumber,
                        PageSize = _pageSize
                    }
                }
            );
        }

        async public Task<ApiResponse<GetPagedRecordsResponse>> SendAsync(Action<GetRecordsByAppRequestBuilderOptions> options)
        {
            var opts = new GetRecordsByAppRequestBuilderOptions();
            options.Invoke(opts);
            return await _client.GetRecordsForAppAsync(
                new GetRecordsByAppRequest
                {
                    AppId = _appId,
                    FieldIds = opts.FieldIds.ToList(),
                    DataFormat = opts.DataFormat,
                    PagingRequest = new PagingRequest
                    {
                        PageNumber = opts.PageNumber,
                        PageSize = opts.PageSize,
                    }
                }
            );
        }
    }
}