using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve fields by app.
    /// </summary>
    public interface IGetFieldsByAppRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the app to retrieve fields for.
        /// </summary>
        int AppId { get; }

        /// <summary>
        /// Gets the page number to retrieve.
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        /// Gets the page size to retrieve.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Specifies the page number to retrieve.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve.</param>
        /// <returns>A <see cref="IGetFieldsByAppRequestBuilder"/> for further configuration of the request.</returns>
        IGetFieldsByAppRequestBuilder ForPage(int pageNumber);

        /// <summary>
        /// Specifies the page size to retrieve.
        /// </summary>
        /// <param name="pageSize">The page size to retrieve.</param>
        /// <returns>A <see cref="IGetFieldsByAppRequestBuilder"/> for further configuration of the request.</returns>
        IGetFieldsByAppRequestBuilder WithPageSize(int pageSize);

        /// <summary>
        /// Asynchronously sends the request to retrieve the fields.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{GetPagedFieldsResponse}"/> when complete.</returns>
        Task<ApiResponse<GetPagedFieldsResponse>> SendAsync();

        /// <summary>
        /// Asynchronously sends the request to retrieve the fields.
        /// </summary>
        /// <param name="options">An action constructs the options for the request.</param>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{GetPagedFieldsResponse}"/> when complete.</returns>
        Task<ApiResponse<GetPagedFieldsResponse>> SendAsync(Action<GetFieldsByAppRequestBuilderOptions> options);
    }
}