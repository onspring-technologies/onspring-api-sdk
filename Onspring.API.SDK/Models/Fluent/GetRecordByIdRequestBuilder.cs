using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetRecordByIdRequestBuilder : IGetRecordByIdRequestBuilder
    {
        private readonly IOnspringClient _client;
        private readonly int _appId;
        private readonly int _recordId;
        private IEnumerable<int> _fieldIds = Enumerable.Empty<int>();
        private DataFormat _dataFormat = DataFormat.Raw;

        public GetRecordByIdRequestBuilder(IOnspringClient client, int appId, int recordId)
        {
            _client = client;
            _appId = appId;
            _recordId = recordId;
        }

        public IGetRecordByIdRequestBuilder WithFieldIds(IEnumerable<int> fieldIds)
        {
            _fieldIds = fieldIds;
            return this;
        }

        public IGetRecordByIdRequestBuilder WithFormat(DataFormat dataFormat)
        {
            _dataFormat = dataFormat;
            return this;
        }

        async public Task<ApiResponse<ResultRecord>> SendAsync()
        {
            return await _client.GetRecordAsync(
                new GetRecordRequest
                {
                    AppId = _appId,
                    RecordId = _recordId,
                    FieldIds = _fieldIds.ToList(),
                    DataFormat = _dataFormat,
                }
            );
        }

        async public Task<ApiResponse<ResultRecord>> SendAsync(Action<GetRecordByIdRequestBuilderOptions> options)
        {
            var opts = new GetRecordByIdRequestBuilderOptions();
            options.Invoke(opts);
            return await _client.GetRecordAsync(
                new GetRecordRequest
                {
                    AppId = _appId,
                    RecordId = _recordId,
                    FieldIds = opts.FieldIds.ToList(),
                    DataFormat = opts.DataFormat,
                }
            );
        }
    }
}