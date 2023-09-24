using System;
using System.Collections.Generic;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to get records by app.
    /// </summary>
    public interface IGetRecordsByAppRequestBuilder
    {
        /// <summary>
        /// Gets the app from which to retrieve records.
        /// </summary>
        int AppId { get; }

        /// <summary>
        /// Specifies the page number to retrieve.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve. Must be greater than zero.</param>
        /// <returns>A <see cref="IGetRecordsByAppPagedRequestBuilder"/> for further configuration of the request.</returns>
        IGetRecordsByAppPagedRequestBuilder ForPage(int pageNumber);

        /// <summary>
        /// Specifies the record ID to retrieve.
        /// </summary>
        /// <param name="recordId">The ID of the record to retrieve.</param>
        /// <returns>A builder <see cref="IGetRecordByIdRequestBuilder"/> for further configuration of the request.</returns>
        IGetRecordByIdRequestBuilder WithId(int recordId);

        /// <summary>
        /// Specifies the IDs of the records to retrieve.
        /// </summary>
        /// <param name="recordIds">The IDs of the records to retrieve.</param>
        /// <returns>A builder <see cref="IGetRecordsByIdsRequestBuilder"/> for further configuration of the request.</returns>
        IGetRecordsByIdsRequestBuilder WithIds(IEnumerable<int> recordIds);

        /// <summary>
        /// Specifies the filter to be used to query records.
        /// </summary>
        /// <param name="filter">The filter to be used to query record</param>
        /// <returns>A <see cref="IQueryRecordsByAppPagedRequestBuilder"/> for further configuration of the request.</returns>
        IQueryRecordsByAppPagedRequestBuilder WithFilter(string filter);

        /// <summary>
        /// Specifies the filter to be used to query records.
        /// </summary>
        /// <param name="filter">An action that constructs the filter to be used to query record</param>
        /// <returns>A <see cref="IQueryRecordsByAppPagedRequestBuilder"/> for further configuration of the request.</returns>
        IQueryRecordsByAppPagedRequestBuilder WithFilter(Action<Filter> filter);
    }
}