using System.Collections.Generic;
using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetFieldsByIdsRequestBuilder
    {
        IEnumerable<int> FieldIds { get; }
        Task<ApiResponse<GetFieldsResponse>> SendAsync();
    }
}