using System.Collections.Generic;
using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetRecordsByAppRequestBuilder
    {
        Task<ApiResponse<GetPagedRecordsResponse>> SendAsync();
        IGetRecordsByAppRequestBuilder ForPage(int pageNumber);
        IGetRecordsByAppRequestBuilder WithPageSize(int pageSize);
        IGetRecordsByAppRequestBuilder WithFieldIds(IEnumerable<int> fieldIds);
    }
}