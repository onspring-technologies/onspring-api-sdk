using System.Collections.Generic;
using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve fields by IDs.
    /// </summary>
    public interface IGetFieldsByIdsRequestBuilder
    {
        /// <summary>
        /// Gets the IDs of the fields to retrieve.
        /// </summary>
        IEnumerable<int> FieldIds { get; }

        /// <summary>
        /// Asynchronously sends the request to retrieve the fields.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{GetFieldsResponse}"/> when complete.</returns>
        Task<ApiResponse<GetFieldsResponse>> SendAsync();
    }
}