using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents options for a request to get a report.
    /// </summary>
    public class GetReportBuilderOptions
    {
        /// <summary>
        /// Gets or sets the format of the report data.
        /// </summary>
        public DataFormat Format { get; set; } = DataFormat.Raw;

        /// <summary>
        /// Gets or sets the type of report data to return.
        /// </summary>
        public ReportDataType DataType { get; set; } = ReportDataType.ReportData;
    }
}