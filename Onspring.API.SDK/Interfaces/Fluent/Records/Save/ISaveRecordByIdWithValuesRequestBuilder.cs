using System.Collections.Generic;
using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface ISaveRecordByIdWithValuesRequestBuilder
    {
        int AppId { get; }
        int? RecordId { get; }
        IEnumerable<RecordFieldValue> Values { get; }
        Task<ApiResponse<SaveRecordResponse>> SendAsync();
    }
}