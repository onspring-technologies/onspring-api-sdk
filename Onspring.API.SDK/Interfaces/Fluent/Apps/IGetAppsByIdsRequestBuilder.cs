using Onspring.API.SDK.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve apps by IDs
    /// </summary>
    public interface IGetAppsByIdsRequestBuilder
    {
        /// <summary>
        /// Gets the IDs of the apps to retrieve.
        /// </summary>
        IEnumerable<int> AppIds { get; }

        /// <summary>
        /// Asynchronously sends the request to retrieve the apps.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{GetAppsResponse}"/> when complete.</returns>
        Task<ApiResponse<GetAppsResponse>> SendAsync();
    }
}