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
        public int AppId { get; private set; }
        public IEnumerable<int> RecordIds { get; private set; }
        public IEnumerable<int> FieldIds { get; private set; } = Enumerable.Empty<int>();
        public DataFormat Format { get; private set; } = DataFormat.Raw;

        internal GetRecordsByIdsRequestBuilder(IOnspringClient client, int appId, IEnumerable<int> recordIds)
        {
            _client = client;
            AppId = appId;
            RecordIds = recordIds;
        }

        public IGetRecordsByIdsRequestBuilder WithFieldIds(IEnumerable<int> fieldIds)
        {
            FieldIds = fieldIds;
            return this;
        }

        public IGetRecordsByIdsRequestBuilder WithFormat(DataFormat dataFormat)
        {
            Format = dataFormat;
            return this;
        }

        async public Task<ApiResponse<GetRecordsResponse>> SendAsync()
        {
            return await _client.GetRecordsAsync(
                new GetRecordsRequest
                {
                    AppId = AppId,
                    RecordIds = RecordIds.ToList(),
                    FieldIds = FieldIds.ToList(),
                    DataFormat = Format,
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
                    AppId = AppId,
                    RecordIds = RecordIds.ToList(),
                    FieldIds = opts.FieldIds.ToList(),
                    DataFormat = opts.Format,
                }
            );
        }
    }
}