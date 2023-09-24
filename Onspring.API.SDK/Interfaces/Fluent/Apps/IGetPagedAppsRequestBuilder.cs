using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetPagedAppsRequestBuilder
    {
        int PageNumber { get; }
        int PageSize { get; }
        IGetPagedAppsRequestBuilder WithPageSize(int pageSize);
        Task<ApiResponse<GetPagedAppsResponse>> SendAsync();
    }
}