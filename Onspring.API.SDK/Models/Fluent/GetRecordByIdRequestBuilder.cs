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
        public int AppId { get; private set; }
        public int RecordId { get; private set; }
        public IEnumerable<int> FieldIds { get; private set; } = Enumerable.Empty<int>();
        public DataFormat Format { get; private set; } = DataFormat.Raw;

        internal GetRecordByIdRequestBuilder(IOnspringClient client, int appId, int recordId)
        {
            _client = client;
            AppId = appId;
            RecordId = recordId;
        }

        public IGetRecordByIdRequestBuilder WithFieldIds(IEnumerable<int> fieldIds)
        {
            FieldIds = fieldIds;
            return this;
        }

        public IGetRecordByIdRequestBuilder WithFormat(DataFormat dataFormat)
        {
            Format = dataFormat;
            return this;
        }

        async public Task<ApiResponse<ResultRecord>> SendAsync()
        {
            return await _client.GetRecordAsync(
                new GetRecordRequest
                {
                    AppId = AppId,
                    RecordId = RecordId,
                    FieldIds = FieldIds.ToList(),
                    DataFormat = Format,
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
                    AppId = AppId,
                    RecordId = RecordId,
                    FieldIds = opts.FieldIds.ToList(),
                    DataFormat = opts.Format,
                }
            );
        }
    }
}