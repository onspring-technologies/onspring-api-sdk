using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetFileInfoByIdRequestBuilder
    {
        int RecordId { get; }
        int FieldId { get; }
        int FileId { get; }
        Task<ApiResponse<GetFileInfoResponse>> SendAsync();
    }
}