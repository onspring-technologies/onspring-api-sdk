using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetRecordsByIdsRequestBuilder : IGetRecordsByIdsRequestBuilder
    {
        private readonly IOnspringClient _client;
        private readonly int _appId;
        private readonly IEnumerable<int> _recordIds;
        private IEnumerable<int> _fieldIds = Enumerable.Empty<int>();
        private DataFormat _dataFormat = DataFormat.Raw;

        public GetRecordsByIdsRequestBuilder(IOnspringClient client, int appId, IEnumerable<int> recordIds)
        {
            _client = client;
            _appId = appId;
            _recordIds = recordIds;
        }

        public IGetRecordsByIdsRequestBuilder WithFieldIds(IEnumerable<int> fieldIds)
        {
            _fieldIds = fieldIds;
            return this;
        }

        public IGetRecordsByIdsRequestBuilder WithFormat(DataFormat dataFormat)
        {
            _dataFormat = dataFormat;
            return this;
        }

        async public Task<ApiResponse<GetRecordsResponse>> SendAsync()
        {
            return await _client.GetRecordsAsync(
                new GetRecordsRequest
                {
                    AppId = _appId,
                    RecordIds = _recordIds.ToList(),
                    FieldIds = _fieldIds.ToList(),
                    DataFormat = _dataFormat,
                }
            );
        }

        async public Task<ApiResponse<GetRecordsResponse>> SendAsync(Action<GetRecordsByIdsRequestBuilderOptions> options)
        {
            var opts = new GetRecordsByIdsRequestBuilderOptions();
            options.Invoke(opts);
            return await _client.GetRecordsAsync(
                new GetRecordsRequest
                {
                    AppId = _appId,
                    RecordIds = _recordIds.ToList(),
                    FieldIds = opts.FieldIds.ToList(),
                    DataFormat = opts.DataFormat,
                }
            );
        }
    }
}