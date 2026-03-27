using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System;
using System.Collections.Generic;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a request builder to retrieve all pages of fields.
    /// </summary>
    public interface IGetAllFieldsPagesByAppRequestBuilder
    {
        /// <summary>
        /// Gets the app ID to retrieve fields for.
        /// </summary>
        int AppId { get; }

        /// <summary>
        /// Gets the page size to retrieve. The default is 50.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Sets the page size to retrieve.
        /// </summary>
        /// <param name="pageSize">The page size to retrieve.</param>
        /// <returns>The current instance of the <see cref="IGetAllFieldsPagesByAppRequestBuilder"/>.</returns>
        IGetAllFieldsPagesByAppRequestBuilder WithPageSize(int pageSize);

        /// <summary>
        /// Sends the request to retrieve all pages of fields for an app.
        /// </summary>
        /// <returns>An async enumerable of <see cref="ApiResponse{T}"/> where T is <see cref="GetPagedFieldsResponse"/>.</returns>
        IAsyncEnumerable<ApiResponse<GetPagedFieldsResponse>> SendAsync();

        /// <summary>
        /// Sends the request to retrieve all pages of fields for an app with the specified options.
        /// </summary>
        /// <param name="options">The options to use for the request.</param>
        /// <returns>An async enumerable of <see cref="ApiResponse{T}"/> where T is <see cref="GetPagedFieldsResponse"/>.</returns>
        IAsyncEnumerable<ApiResponse<GetPagedFieldsResponse>> SendAsync(Action<GetAllFieldsPagesByAppRequestBuilderOptions> options);
    }
}