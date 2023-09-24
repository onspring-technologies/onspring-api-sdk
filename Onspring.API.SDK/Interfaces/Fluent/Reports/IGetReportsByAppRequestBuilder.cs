using System;
using System.Threading.Tasks;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to get reports from an app.
    /// </summary>
    public interface IGetReportsByAppRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the app from which to get reports.
        /// </summary>
        int AppId { get; }

        /// <summary>
        /// Gets the page number of the reports to get.
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        /// Gets the page size of the page of reports to get.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Specifies the page number of the reports to get.
        /// </summary>
        /// <param name="pageNumber">The page number of the reports to get.</param>
        /// <returns>A <see cref="IGetReportsByAppRequestBuilder"/> for further configuration of the request.</returns>
        IGetReportsByAppRequestBuilder ForPage(int pageNumber);

        /// <summary>
        /// Specifies the page size of the page of reports to get.
        /// </summary>
        /// <param name="pageNumber">The page size of the page of reports to get.</param>
        /// <returns>A <see cref="IGetReportsByAppRequestBuilder"/> for further configuration of the request.</returns>
        IGetReportsByAppRequestBuilder WithPageSize(int pageNumber);

        /// <summary>
        /// Asynchronously sends the request.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{GetReportsForAppResponse}"/> when complete.</returns>
        Task<ApiResponse<GetReportsForAppResponse>> SendAsync();

        /// <summary>
        /// Asynchronously sends the request with the specified options.
        /// </summary>
        /// <param name="options">An action that constructs the options to use for the request.</param>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{GetReportsForAppResponse}"/> when complete.</returns>
        Task<ApiResponse<GetReportsForAppResponse>> SendAsync(Action<GetReportsRequestBuilderOptions> options);
    }
}