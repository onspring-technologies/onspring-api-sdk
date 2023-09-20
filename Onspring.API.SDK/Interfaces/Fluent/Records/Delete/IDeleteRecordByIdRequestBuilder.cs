using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IDeleteRecordByIdRequestBuilder
    {
        int AppId { get; }
        int RecordId { get; }
        Task<ApiResponse> SendAsync();
    }
}