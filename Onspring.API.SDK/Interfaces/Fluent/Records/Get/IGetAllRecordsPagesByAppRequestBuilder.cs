using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System;
using System.Collections.Generic;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a request builder for getting all pages of records from an app.
    /// </summary>
    public interface IGetAllRecordsPagesByAppRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the app to retrieve records from.
        /// </summary>
        int AppId { get; }

        /// <summary>
        /// Gets the page size to use when retrieving records. The default is 50.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Gets the data format to use when retrieving records. The default is <see cref="DataFormat.Raw"/>.
        /// </summary>
        DataFormat DataFormat { get; }

        /// <summary>
        /// Gets the IDs of the fields to retrieve with the records.
        /// </summary>
        IEnumerable<int> FieldIds { get; }

        /// <summary>
        /// Specifies the fields to retrieve with the records.
        /// </summary>
        /// <param name="fieldIds">The IDs of the fields to retrieve with the records.</param>
        /// <returns>A <see cref="IGetAllRecordsPagesByAppRequestBuilder"/> for further configuration of the request.</returns>
        IGetAllRecordsPagesByAppRequestBuilder WithFields(IEnumerable<int> fieldIds);

        /// <summary>
        /// Specifies the data format to use when retrieving records.
        /// </summary>
        /// <param name="dataFormat">The data format to use when retrieving records.</param>
        /// <returns>A <see cref="IGetAllRecordsPagesByAppRequestBuilder"/> for further configuration of the request.</returns>
        IGetAllRecordsPagesByAppRequestBuilder WithDataFormat(DataFormat dataFormat);

        /// <summary>
        /// Specifies the page size to use when retrieving records.
        /// </summary>
        /// <param name="pageSize">The page size to use when retrieving records. Must be greater than zero.</param>
        /// <returns>A <see cref="IGetAllRecordsPagesByAppRequestBuilder"/> for further configuration of the request.</returns>
        IGetAllRecordsPagesByAppRequestBuilder WithPageSize(int pageSize);

        /// <summary>
        /// Specifies the filter to be used to query records.
        /// </summary>
        /// <param name="filter">The filter to be used to query records.</param>
        /// <returns>A <see cref="IGetAllRecordsPagesByQueryRequestBuilder"/> for further configuration of the request.</returns>
        IGetAllRecordsPagesByQueryRequestBuilder WithFilter(string filter);

        /// <summary>
        /// Specifies the filter to be used to query records.
        /// </summary>
        /// <param name="filter">An action that constructs the filter to be used to query records.</param>
        /// <returns>A <see cref="IGetAllRecordsPagesByQueryRequestBuilder"/> for further configuration of the request.</returns>
        IGetAllRecordsPagesByQueryRequestBuilder WithFilter(Action<Filter> filter);

        /// <summary>
        /// Sends the request to get all pages of records from the app.
        /// </summary>
        /// <returns>An async enumerable of <see cref="ApiResponse{T}"/> where T is <see cref="GetPagedRecordsResponse"/>.</returns>
        IAsyncEnumerable<ApiResponse<GetPagedRecordsResponse>> SendAsync();

        /// <summary>
        /// Sends the request to get all pages of records from the app.
        /// </summary>
        /// <param name="options">An action that configures the request options.</param>
        /// <returns>An async enumerable of <see cref="ApiResponse{T}"/> where T is <see cref="GetPagedRecordsResponse"/>.</returns>
        IAsyncEnumerable<ApiResponse<GetPagedRecordsResponse>> SendAsync(Action<GetAllRecordsPagesByAppRequestBuilderOptions> options);
    }
}
