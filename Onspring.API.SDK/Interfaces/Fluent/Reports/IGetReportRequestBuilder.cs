namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to get a report.
    /// </summary>
    public interface IGetReportRequestBuilder
    {
        /// <summary>
        /// Specifies the ID of the report to get.
        /// </summary>
        /// <param name="reportId">The ID of the report to get.</param>
        /// <returns>A <see cref="IGetReportDataRequestBuilder"/> for further configuration of the request.</returns>
        IGetReportDataRequestBuilder FromReport(int reportId);
    }
}