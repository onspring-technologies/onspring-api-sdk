using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// A builder for constructing requests to get records by IDs.
    /// </summary>
    /// <inheritdoc/>
    public class GetRecordsByIdsRequestBuilder : IGetRecordsByIdsRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; private set; }
        public IEnumerable<int> RecordIds { get; private set; }
        public IEnumerable<int> FieldIds { get; private set; } = Enumerable.Empty<int>();
        public DataFormat Format { get; private set; } = DataFormat.Raw;

        /// <summary>
        /// Creates a new instance of the <see cref="GetRecordsByIdsRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IOnspringClient"/> used to send the request.</param>
        /// <param name="appId">The unique identifier of the app from which to retrieve records.</param>
        /// <param name="recordIds">The unique identifiers of the records to retrieve.</param>
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