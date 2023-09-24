using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to query records from an app.
    /// </summary>
    public interface IQueryRecordsByAppPagedRequestBuilder
    {
        /// <summary>
        /// Gets the application ID.
        /// </summary>
        int AppId { get; }

        /// <summary>
        /// Gets the filter.
        /// </summary>
        string Filter { get; }

        /// <summary>
        /// Gets the page number.
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        /// Gets the page size.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Gets the field IDs.
        /// </summary>
        IEnumerable<int> FieldIds { get; }

        /// <summary>
        /// Gets the data format.
        /// </summary>
        DataFormat Format { get; }

        /// <summary>
        /// Sends the request asynchronously.
        /// </summary>
        /// <returns>An awaitable task that returns an API response when complete.</returns>
        /// <see cref="ApiResponse{T}"/> 
        /// <see cref="GetPagedRecordsResponse"/> 
        Task<ApiResponse<GetPagedRecordsResponse>> SendAsync();

        /// <summary>
        /// Sends the request asynchronously with the specified options.
        /// </summary>
        /// <param name="options">The options to use when sending the request.</param>
        /// <returns>An awaitable task that returns an API response when complete.</returns>
        /// <see cref="ApiResponse{T}"/> 
        /// <see cref="GetPagedRecordsResponse"/> 
        Task<ApiResponse<GetPagedRecordsResponse>> SendAsync(Action<QueryRecordsByAppPagedRequestBuilderOptions> options);

        /// <summary>
        /// Sets the page number to retrieve.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve</param>
        /// <returns>A builder for further configuration of the request.</returns>
        IQueryRecordsByAppPagedRequestBuilder ForPage(int pageNumber);

        /// <summary>
        /// Sets the page size to retrieve.
        /// </summary>
        /// <param name="pageSize">The size of page to retrieve</param>
        /// <returns>A builder for further configuration of the request.</returns>
        IQueryRecordsByAppPagedRequestBuilder WithPageSize(int pageSize);

        /// <summary>
        /// Sets the field IDs to retrieve.
        /// </summary>
        /// <param name="fieldIds">The field IDs to retrieve</param>
        /// <returns>A builder for further configuration of the request.</returns>
        IQueryRecordsByAppPagedRequestBuilder WithFieldIds(IEnumerable<int> fieldIds);

        /// <summary>
        /// Sets the format of the data to retrieve.
        /// </summary>
        /// <param name="dataFormat">The format of the data to retrieve</param>
        /// <returns>A builder for further configuration of the request.</returns>
        IQueryRecordsByAppPagedRequestBuilder WithFormat(DataFormat dataFormat);

    }
}