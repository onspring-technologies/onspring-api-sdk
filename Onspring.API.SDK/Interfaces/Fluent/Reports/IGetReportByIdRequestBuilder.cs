using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetReportByIdRequestBuilder
    {
        int ReportId { get; }
        Task<ApiResponse<ReportData>> SendAsync();
    }
}