using System;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetReportDataRequestBuilder
    {
        int ReportId { get; }
        DataFormat Format { get; }
        ReportDataType DataType { get; }
        IGetReportDataRequestBuilder WithFormat(DataFormat format);
        IGetReportDataRequestBuilder WithDataType(ReportDataType dataType);
        Task<ApiResponse<ReportData>> SendAsync();
        Task<ApiResponse<ReportData>> SendAsync(Action<GetReportBuilderOptions> options);
    }
}