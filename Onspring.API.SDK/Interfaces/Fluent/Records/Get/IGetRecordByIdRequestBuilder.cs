using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to get a record by ID.
    /// </summary>
    public interface IGetRecordByIdRequestBuilder
    {
        /// <summary>
        /// Gets the app from which to retrieve records.
        /// </summary>
        int AppId { get; }

        /// <summary>
        /// Gets the ID of the record to retrieve.
        /// </summary>
        int RecordId { get; }

        /// <summary>
        /// Gets the IDs of the fields to retrieve.
        /// </summary>
        IEnumerable<int> FieldIds { get; }

        /// <summary>
        /// Gets the data format for the response.
        /// </summary>
        DataFormat Format { get; }

        /// <summary>
        /// Sends the request asynchronously.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{ResultRecord}"/> when complete.</returns>
        Task<ApiResponse<ResultRecord>> SendAsync();

        /// <summary>
        /// Sends the request asynchronously with the specified options.
        /// </summary>
        /// <param name="options">An action that constructs the options to use when sending the request.</param>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{ResultRecord}"/> when complete.</returns>
        Task<ApiResponse<ResultRecord>> SendAsync(Action<GetRecordByIdRequestBuilderOptions> options);

        /// <summary>
        /// Specifies the IDs of the fields to retrieve.
        /// </summary>
        /// <param name="fieldIds">The IDs of the fields to retrieve.</param>
        /// <returns>A builder for further configuration of the request.</returns>
        IGetRecordByIdRequestBuilder WithFieldIds(IEnumerable<int> fieldIds);

        /// <summary>
        /// Specifies the data format for the response.
        /// </summary>
        /// <param name="dataFormat">The data format for the response.</param>
        /// <returns>A builder for further configuration of the request.</returns>
        IGetRecordByIdRequestBuilder WithFormat(DataFormat dataFormat);
    }
}