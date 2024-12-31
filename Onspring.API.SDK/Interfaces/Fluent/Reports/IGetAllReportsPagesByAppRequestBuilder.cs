using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System;
using System.Collections.Generic;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Interface for building requests to get all pages of reports for a specific app.
    /// </summary>
    public interface IGetAllReportsPagesByAppRequestBuilder
    {
        /// <summary>
        /// Gets the app ID for the request.
        /// </summary>
        int AppId { get; }

        /// <summary>
        /// Gets the page size for the request. Default is 50.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Sets the page size for the request.
        /// </summary>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A <see cref="IGetAllReportsPagesByAppRequestBuilder"/> for further configuration of the request.</returns>
        IGetAllReportsPagesByAppRequestBuilder WithPageSize(int pageSize);

        /// <summary>
        /// Sends the request to retrieve all pages of reports for the app.
        /// </summary>
        /// <returns>An async enumerable of <see cref="ApiResponse{T}"/> where T is <see cref="GetReportsForAppResponse"/>.</returns>
        IAsyncEnumerable<ApiResponse<GetReportsForAppResponse>> SendAsync();

        /// <summary>
        /// Sends the request to retrieve all pages of reports for the app with the specified options.
        /// </summary>
        /// <param name="options">The options to use for the request.</param>
        /// <returns>An async enumerable of <see cref="ApiResponse{T}"/> where T is <see cref="GetReportsForAppResponse"/>.</returns>
        IAsyncEnumerable<ApiResponse<GetReportsForAppResponse>> SendAsync(Action<GetAllReportsPagesByAppRequestBuilderOptions> options);
    }
}