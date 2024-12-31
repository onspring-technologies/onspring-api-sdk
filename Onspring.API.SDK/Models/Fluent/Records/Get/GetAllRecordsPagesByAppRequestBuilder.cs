using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Interfaces.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a request builder for getting all pages of records from an app.
    /// </summary>
    /// <inheritdoc />
    public class GetAllRecordsPagesByAppRequestBuilder : IGetAllRecordsPagesByAppRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; }
        public int PageSize { get; private set; } = 50;
        public DataFormat DataFormat { get; private set; } = DataFormat.Raw;
        public IEnumerable<int> FieldIds { get; private set; } = Enumerable.Empty<int>();

        internal GetAllRecordsPagesByAppRequestBuilder(IOnspringClient client, int appId)
        {
            _client = client;
            AppId = appId;
        }

        public IGetAllRecordsPagesByAppRequestBuilder WithDataFormat(DataFormat dataFormat)
        {
            DataFormat = dataFormat;
            return this;
        }

        public IGetAllRecordsPagesByAppRequestBuilder WithFields(IEnumerable<int> fieldIds)
        {
            FieldIds = fieldIds;
            return this;
        }

        public IGetAllRecordsPagesByAppRequestBuilder WithPageSize(int pageSize)
        {
            PageSize = pageSize;
            return this;
        }

        public IGetAllRecordsPagesByQueryRequestBuilder WithFilter(string filter)
        {
            return new GetAllRecordsPagesByQueryRequestBuilder(
                _client,
                AppId,
                PageSize,
                FieldIds,
                DataFormat,
                filter
            );
        }

        public IGetAllRecordsPagesByQueryRequestBuilder WithFilter(Action<Filter> filter)
        {
            return new GetAllRecordsPagesByQueryRequestBuilder(
                _client,
                AppId,
                PageSize,
                FieldIds,
                DataFormat,
                filter.ToString()
            );
        }

        public async IAsyncEnumerable<ApiResponse<GetPagedRecordsResponse>> SendAsync()
        {
            var request = new GetRecordsByAppRequest
            {
                AppId = AppId,
                PagingRequest = new PagingRequest { PageSize = PageSize },
                DataFormat = DataFormat,
                FieldIds = FieldIds.ToList(),
            };

            await foreach (var response in _client.GetAllRecordsForAppAsync(request))
            {
                yield return response;
            }
        }

        public async IAsyncEnumerable<ApiResponse<GetPagedRecordsResponse>> SendAsync(Action<GetAllRecordsPagesByAppRequestBuilderOptions> options)
        {
            var opts = new GetAllRecordsPagesByAppRequestBuilderOptions();
            options.Invoke(opts);

            var request = new GetRecordsByAppRequest
            {
                AppId = AppId,
                PagingRequest = new PagingRequest { PageSize = opts.PageSize },
                DataFormat = opts.DataFormat,
                FieldIds = opts.FieldIds.ToList(),
            };

            await foreach (var response in _client.GetAllRecordsForAppAsync(request))
            {
                yield return response;
            }
        }
    }
}