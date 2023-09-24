using Onspring.API.SDK.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to save a record by ID with values.
    /// </summary>
    public interface ISaveRecordByIdWithValuesRequestBuilder
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
        /// Gets the field values to save.
        /// </summary>
        IEnumerable<RecordFieldValue> Values { get; }

        /// <summary>
        /// Asynchronously sends the request.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{SaveRecordResponse}"/> when complete.</returns>
        Task<ApiResponse<SaveRecordResponse>> SendAsync();
    }
}