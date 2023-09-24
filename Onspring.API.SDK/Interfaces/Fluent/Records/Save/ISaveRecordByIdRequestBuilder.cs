using Onspring.API.SDK.Models;
using System.Collections.Generic;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to save a record by ID.
    /// </summary>
    public interface ISaveRecordByIdRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the app in which to save the record.
        /// </summary>
        int AppId { get; }

        /// <summary>
        /// Gets the ID of the record to save.
        /// </summary>
        int? RecordId { get; }

        /// <summary>
        /// Specifies the field values to save.
        /// </summary>
        /// <param name="values">The field values to save.</param>
        /// <returns>A <see cref="ISaveRecordByIdWithValuesRequestBuilder"/> for further configuration of the request.</returns>
        ISaveRecordByIdWithValuesRequestBuilder WithValues(IEnumerable<RecordFieldValue> values);
    }
}