using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Interfaces.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to get all pages of records from an app by query.
    /// </summary>
    /// <inheritdoc/>
    public class GetAllRecordsPagesByQueryRequestBuilder : IGetAllRecordsPagesByQueryRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; }
        public int PageSize { get; private set; } = 50;
        public DataFormat DataFormat { get; private set; } = DataFormat.Raw;
        public IEnumerable<int> FieldIds { get; private set; } = Enumerable.Empty<int>();
        public string Filter { get; private set; }

        internal GetAllRecordsPagesByQueryRequestBuilder(
            IOnspringClient client,
            int appId,
            int pageSize,
            IEnumerable<int> fieldIds,
            DataFormat dataFormat,
            string filter
        )
        {
            _client = client;
            AppId = appId;
            PageSize = pageSize;
            FieldIds = fieldIds;
            DataFormat = dataFormat;
            Filter = filter;
        }

        public IGetAllRecordsPagesByQueryRequestBuilder WithDataFormat(DataFormat dataFormat)
        {
            DataFormat = dataFormat;
            return this;
        }

        public IGetAllRecordsPagesByQueryRequestBuilder WithFields(IEnumerable<int> fieldIds)
        {
            FieldIds = fieldIds;
            return this;
        }

        public IGetAllRecordsPagesByQueryRequestBuilder WithPageSize(int pageSize)
        {
            PageSize = pageSize;
            return this;
        }

        public IGetAllRecordsPagesByQueryRequestBuilder WithFilter(string filter)
        {
            Filter = filter;
            return this;
        }

        public IGetAllRecordsPagesByQueryRequestBuilder WithFilter(Action<Filter> filter)
        {
            Filter = filter.ToString();
            return this;
        }

        public async IAsyncEnumerable<ApiResponse<GetPagedRecordsResponse>> SendAsync()
        {
            var request = new QueryRecordsRequest
            {
                AppId = AppId,
                DataFormat = DataFormat,
                FieldIds = FieldIds.ToList(),
                Filter = Filter
            };

            await foreach (var response in _client.GetAllRecordsByQueryAsync(request, PageSize))
            {
                yield return response;
            }
        }

        public async IAsyncEnumerable<ApiResponse<GetPagedRecordsResponse>> SendAsync(Action<GetAllRecordsPagesByQueryRequestBuilderOptions> options)
        {
            var opts = new GetAllRecordsPagesByQueryRequestBuilderOptions();
            options.Invoke(opts);

            var request = new QueryRecordsRequest
            {
                AppId = AppId,
                DataFormat = DataFormat,
                FieldIds = FieldIds.ToList(),
                Filter = Filter
            };

            await foreach (var response in _client.GetAllRecordsByQueryAsync(request, opts.PageSize))
            {
                yield return response;
            }
        }
    }
}