using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetFieldByIdRequestBuilder
    {
        int FieldId { get; }
        Task<ApiResponse<Field>> SendAsync();
    }
}