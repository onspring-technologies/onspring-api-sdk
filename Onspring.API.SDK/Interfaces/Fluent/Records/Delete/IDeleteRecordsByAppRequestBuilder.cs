using System.Collections;
using System.Collections.Generic;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to delete records from an app.
    /// </summary>
    public interface IDeleteRecordsByAppRequestBuilder
    {
        /// <summary>
        /// Specifies the ID of the app from which to delete records.
        /// </summary>
        int AppId { get; }

        /// <summary>
        /// Specifies the ID of the record to delete.
        /// </summary>
        /// <param name="recordId">The ID of the record to delete.</param>
        /// <returns>A <see cref="IDeleteRecordByIdRequestBuilder"/> for further configuration of the request.</returns>
        IDeleteRecordByIdRequestBuilder WithId(int recordId);

        /// <summary>
        /// Specifies the IDs of the records to delete.
        /// </summary>
        /// <param name="recordIds">The IDs of the records to delete.</param>
        /// <returns>A <see cref="IDeleteRecordsByIdsRequestBuilder"/> for further configuration of the request.</returns>
        IDeleteRecordsByIdsRequestBuilder WithIds(IEnumerable<int> recordIds);
    }
}