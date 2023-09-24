using Onspring.API.SDK.Models;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to delete a file.
    /// </summary>
    public interface IDeleteFileByIdRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the record to delete the file from.
        /// </summary>
        int RecordId { get; }

        /// <summary>
        /// Gets the ID of the field to delete the file from.
        /// </summary>
        int FieldId { get; }

        /// <summary>
        /// Gets the ID of the file to delete.
        /// </summary>
        int FileId { get; }

        /// <summary>
        /// Asynchronously sends the request to delete the file.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse"/> when complete.</returns>
        Task<ApiResponse> SendAsync();
    }
}