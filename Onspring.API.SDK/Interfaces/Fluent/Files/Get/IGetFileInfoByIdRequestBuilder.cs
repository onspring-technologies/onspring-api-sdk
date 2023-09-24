using Onspring.API.SDK.Models;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve information about a file by its ID.
    /// </summary>
    public interface IGetFileInfoByIdRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the record to retrieve the file information from.
        /// </summary>
        int RecordId { get; }

        /// <summary>
        /// Gets the ID of the field to retrieve the file information from.
        /// </summary>
        int FieldId { get; }

        /// <summary>
        /// Gets the ID of the file to retrieve information about.
        /// </summary>
        int FileId { get; }

        /// <summary>
        /// Asynchronously sends the request to retrieve the file information.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{GetFileInfoResponse}"/> when complete.</returns>
        Task<ApiResponse<GetFileInfoResponse>> SendAsync();
    }
}