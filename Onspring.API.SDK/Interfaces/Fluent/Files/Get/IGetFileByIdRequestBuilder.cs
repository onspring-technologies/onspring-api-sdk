using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve files by id.
    /// </summary>
    public interface IGetFileByIdRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the record to retrieve the file from.
        /// </summary>
        int RecordId { get; }

        /// <summary>
        /// Gets the ID of the field to retrieve the file from.
        /// </summary>
        int FieldId { get; }

        /// <summary>
        /// Gets the ID of the file to retrieve.
        /// </summary>
        int FileId { get; }

        /// <summary>
        /// Asynchronously sends the request to retrieve the file.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{GetFileResponse}"/> when complete.</returns>
        Task<ApiResponse<GetFileResponse>> SendAsync();
    }
}