using System.Collections.Generic;
using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetAppsByIdsRequestBuilder
    {
        IEnumerable<int> AppIds { get; }
        Task<ApiResponse<GetAppsResponse>> SendAsync();
    }
}