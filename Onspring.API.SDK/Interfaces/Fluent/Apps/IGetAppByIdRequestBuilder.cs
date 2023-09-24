using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetAppByIdRequestBuilder
    {
        int AppId { get; }
        Task<ApiResponse<App>> SendAsync();
    }
}