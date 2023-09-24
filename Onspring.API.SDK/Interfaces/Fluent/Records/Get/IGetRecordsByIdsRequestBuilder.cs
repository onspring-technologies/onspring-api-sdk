using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to get records by IDs.
    /// </summary>
    public interface IGetRecordsByIdsRequestBuilder
    {
        /// <summary>
        /// Gets the app from which to retrieve records.
        /// </summary>
        int AppId { get; }

        /// <summary>
        /// Gets the IDs of the records to retrieve.
        /// </summary>
        IEnumerable<int> RecordIds { get; }

        /// <summary>
        /// Gets the IDs of the fields to retrieve.
        /// </summary>
        IEnumerable<int> FieldIds { get; }

        /// <summary>
        /// Gets the data format of the response.
        /// </summary>
        DataFormat Format { get; }

        /// <summary>
        /// Sends the request asynchronously.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{GetRecordsResponse}"/> when complete.</returns>
        Task<ApiResponse<GetRecordsResponse>> SendAsync();

        /// <summary>
        /// Sends the request asynchronously with the specified options.
        /// </summary>
        /// <param name="options">The options to use when sending the request.</param>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{GetRecordsResponse}"/> when complete.</returns>
        Task<ApiResponse<GetRecordsResponse>> SendAsync(Action<GetRecordsByIdsRequestBuilderOptions> options);

        /// <summary>
        /// Specifies the IDs of the fields to retrieve.
        /// </summary>
        /// <param name="fieldIds">The IDs of the fields to retrieve.</param>
        /// <returns>A builder for further configuration of the request.</returns>
        IGetRecordsByIdsRequestBuilder WithFieldIds(IEnumerable<int> fieldIds);

        /// <summary>
        /// Specifies the data format of the response.
        /// </summary>
        /// <param name="dataFormat">The data format of the response.</param>
        /// <returns>A builder for further configuration of the request.</returns>
        IGetRecordsByIdsRequestBuilder WithFormat(DataFormat dataFormat);
    }
}