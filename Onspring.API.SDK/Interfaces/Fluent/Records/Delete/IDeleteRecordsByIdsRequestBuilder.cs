using System.Collections.Generic;
using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IDeleteRecordsByIdsRequestBuilder
    {
        int AppId { get; }
        IEnumerable<int> RecordIds { get; }
        Task<ApiResponse> SendAsync();

    }
}