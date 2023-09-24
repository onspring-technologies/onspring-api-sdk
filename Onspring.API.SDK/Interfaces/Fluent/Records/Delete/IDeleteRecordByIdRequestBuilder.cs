using Onspring.API.SDK.Models;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to delete a record from an app by ID.
    /// </summary>
    public interface IDeleteRecordByIdRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the app from which to delete the record.
        /// </summary>
        int AppId { get; }

        /// <summary>
        /// Gets the ID of the record to delete.
        /// </summary>
        int RecordId { get; }

        /// <summary>
        /// Asynchronously sends the request to delete the record.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse"/> when complete.</returns>
        Task<ApiResponse> SendAsync();
    }
}