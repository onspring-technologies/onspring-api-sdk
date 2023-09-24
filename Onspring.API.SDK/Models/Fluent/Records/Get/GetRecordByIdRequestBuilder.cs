using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Interfaces.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to get a record by ID.
    /// </summary>
    /// <inheritdoc/>
    public class GetRecordByIdRequestBuilder : IGetRecordByIdRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; private set; }
        public int RecordId { get; private set; }
        public IEnumerable<int> FieldIds { get; private set; } = Enumerable.Empty<int>();
        public DataFormat Format { get; private set; } = DataFormat.Raw;

        /// <summary>
        /// Creates a new instance of the <see cref="GetRecordByIdRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IOnspringClient"/> used to send the request.</param>
        /// <param name="appId">The unique identifier of the app from which to retrieve records.</param>
        /// <param name="recordId">The ID of the record to retrieve.</param>
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