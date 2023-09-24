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
        /// <returns>A builder for further configuration of the request.</returns>
        /// <see cref="IGetRecordsByAppPagedRequestBuilder"/>
        IGetRecordsByAppPagedRequestBuilder ForPage(int pageNumber);

        /// <summary>
        /// Specifies the record ID to retrieve.
        /// </summary>
        /// <param name="recordId">The ID of the record to retrieve.</param>
        /// <returns>A builder for further configuration of the request.</returns>
        /// <see cref="IGetRecordByIdRequestBuilder"/>
        IGetRecordByIdRequestBuilder WithId(int recordId);

        /// <summary>
        /// Specifies the IDs of the records to retrieve.
        /// </summary>
        /// <param name="recordIds">The IDs of the records to retrieve.</param>
        /// <returns>A builder for further configuration of the request.</returns>
        /// <see cref="IGetRecordsByIdsRequestBuilder"/>
        IGetRecordsByIdsRequestBuilder WithIds(IEnumerable<int> recordIds);

        /// <summary>
        /// Specifies the filter to be used to query records.
        /// </summary>
        /// <param name="filter">The filter to be used to query record</param>
        /// <returns>A builder for further configuration of the request.</returns>
        /// <see cref="IQueryRecordsByAppPagedRequestBuilder"/>
        IQueryRecordsByAppPagedRequestBuilder WithFilter(string filter);

        /// <summary>
        /// Specifies the filter to be used to query records.
        /// </summary>
        /// <param name="filter">An action <see cref="Action{Filter}"/> that constructs the filter to be used to query record</param>
        /// <returns>A builder for further configuration of the request.</returns>
        /// <see cref="IQueryRecordsByAppPagedRequestBuilder"/>
        IQueryRecordsByAppPagedRequestBuilder WithFilter(Action<Filter> filter);
    }
}