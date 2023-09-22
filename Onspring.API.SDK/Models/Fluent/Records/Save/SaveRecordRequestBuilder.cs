using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class SaveRecordRequestBuilder :
        ISaveRecordRequestBuilder,
        ISaveRecordInAppRequestBuilder,
        ISaveRecordByIdRequestBuilder,
        ISaveRecordByIdWithValuesRequestBuilder
    {
        private readonly IOnspringClient _client;

        internal SaveRecordRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public int AppId { get; private set; }

        public int? RecordId { get; private set; }

        public IEnumerable<RecordFieldValue> Values { get; private set; }

        public ISaveRecordInAppRequestBuilder InApp(int appId)
        {
            AppId = appId;
            return this;
        }

        public ISaveRecordByIdRequestBuilder WithId(int? recordId)
        {
            RecordId = recordId;
            return this;
        }

        public ISaveRecordByIdWithValuesRequestBuilder WithValues(IEnumerable<RecordFieldValue> values)
        {
            Values = values;
            return this;
        }

        public async Task<ApiResponse<SaveRecordResponse>> SendAsync()
        {
            return await _client.SaveRecordAsync(
                new ResultRecord
                {
                    AppId = AppId,
                    RecordId = RecordId ?? 0,
                    FieldData = Values.ToList(),
                }
            );
        }
    }
}