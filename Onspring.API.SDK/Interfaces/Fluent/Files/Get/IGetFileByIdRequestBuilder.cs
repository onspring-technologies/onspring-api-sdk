using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetFileByIdRequestBuilder
    {
        int RecordId { get; }
        int FieldId { get; }
        int FileId { get; }
        Task<ApiResponse<GetFileResponse>> SendAsync();
    }
}