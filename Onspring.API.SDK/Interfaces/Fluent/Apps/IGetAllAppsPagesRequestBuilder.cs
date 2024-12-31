using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System;
using System.Collections.Generic;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a request builder for getting all pages of apps.
    /// </summary>
    public interface IGetAllAppsPagesRequestBuilder
    {
        /// <summary>
        /// Gets the page size to retrieve.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Sets the page size to retrieve.
        /// </summary>
        IGetAllAppsPagesRequestBuilder WithPageSize(int pageSize);

        /// <summary>
        /// Sends the request to retrieve all pages of apps.
        /// </summary>
        /// <returns>An async enumerable of <see cref="ApiResponse{T}"/> where T is <see cref="GetPagedAppsResponse"/>.</returns>
        IAsyncEnumerable<ApiResponse<GetPagedAppsResponse>> SendAsync();

        /// <summary>
        /// Sends the request to retrieve all pages of apps with the specified options.
        /// </summary>
        /// <param name="options">The options to use for the request.</param>
        /// <returns>An async enumerable of <see cref="ApiResponse{T}"/> where T is <see cref="GetPagedAppsResponse"/>.</returns>
        IAsyncEnumerable<ApiResponse<GetPagedAppsResponse>> SendAsync(Action<GetAllAppsPagesRequestBuilderOptions> options);
    }
}