using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetReportDataRequestBuilderOptions
    {
        public DataFormat Format { get; set; } = DataFormat.Raw;
        public ReportDataType DataType { get; set; } = ReportDataType.ReportData;
    }
}