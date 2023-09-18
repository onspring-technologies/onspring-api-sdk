using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetRecordsByIdsRequestBuilder
    {
        int AppId { get; }
        IEnumerable<int> RecordIds { get; }
        IEnumerable<int> FieldIds { get; }
        DataFormat Format { get; }
        Task<ApiResponse<GetRecordsResponse>> SendAsync();
        Task<ApiResponse<GetRecordsResponse>> SendAsync(Action<GetRecordsByIdsRequestBuilderOptions> options);
        IGetRecordsByIdsRequestBuilder WithFieldIds(IEnumerable<int> fieldIds);
        IGetRecordsByIdsRequestBuilder WithFormat(DataFormat dataFormat);
    }
}