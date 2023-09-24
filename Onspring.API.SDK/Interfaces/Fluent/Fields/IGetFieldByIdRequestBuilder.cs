using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve fields by id.
    /// </summary>
    public interface IGetFieldByIdRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the field to retrieve.
        /// </summary>
        int FieldId { get; }

        /// <summary>
        /// Asynchronously sends the request to retrieve the field.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{Field}"/> when complete.</returns>
        Task<ApiResponse<Field>> SendAsync();
    }
}