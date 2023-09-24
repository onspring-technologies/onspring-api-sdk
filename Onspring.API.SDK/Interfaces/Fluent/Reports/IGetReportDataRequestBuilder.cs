using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to get a report's data.
    /// </summary>
    public interface IGetReportDataRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the report to get.
        /// </summary>
        int ReportId { get; }

        /// <summary>
        /// Gets the format of the report data.
        /// </summary>
        DataFormat Format { get; }

        /// <summary>
        /// Gets the type of report data to return.
        /// </summary>
        ReportDataType DataType { get; }

        /// <summary>
        /// Specifies the format of the report data.
        /// </summary>
        /// <param name="format">The format of the report data.</param>
        /// <returns>A <see cref="IGetReportDataRequestBuilder"/> for further configuration of the request.</returns>
        IGetReportDataRequestBuilder WithFormat(DataFormat format);

        /// <summary>
        /// Specifies the type of report data to return.
        /// </summary>
        /// <param name="dataType">The type of report data to return.</param>
        /// <returns>A <see cref="IGetReportDataRequestBuilder"/> for further configuration of the request.</returns>
        IGetReportDataRequestBuilder WithDataType(ReportDataType dataType);

        /// <summary>
        /// Asynchronously sends the request.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{ReportData}"/> when complete.</returns>
        Task<ApiResponse<ReportData>> SendAsync();

        /// <summary>
        /// Asynchronously sends the request with the specified options.
        /// </summary>
        /// <param name="options">An action that constructs the options to use for the request.</param>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{ReportData}"/> when complete.</returns>
        Task<ApiResponse<ReportData>> SendAsync(Action<GetReportBuilderOptions> options);
    }
}