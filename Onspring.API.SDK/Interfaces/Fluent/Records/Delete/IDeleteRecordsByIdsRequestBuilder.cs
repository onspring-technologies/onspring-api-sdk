using System.Collections.Generic;
using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to delete records from an app by IDs.
    /// </summary>
    public interface IDeleteRecordsByIdsRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the app from which to delete records.
        /// </summary>
        int AppId { get; }

        /// <summary>
        /// Gets the IDs of the records to delete.
        /// </summary>
        IEnumerable<int> RecordIds { get; }

        /// <summary>
        /// Asynchronously sends the request to delete the records.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse"/> when complete.</returns>
        Task<ApiResponse> SendAsync();
    }
}