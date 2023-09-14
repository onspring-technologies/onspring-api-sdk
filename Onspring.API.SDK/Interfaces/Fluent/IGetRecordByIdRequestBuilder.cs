using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetRecordByIdRequestBuilder
    {
        Task<ApiResponse<ResultRecord>> SendAsync();
        Task<ApiResponse<ResultRecord>> SendAsync(Action<GetRecordByIdRequestBuilderOptions> options);
        IGetRecordByIdRequestBuilder WithFieldIds(IEnumerable<int> fieldIds);
        IGetRecordByIdRequestBuilder WithFormat(DataFormat dataFormat);
    }
}
