using Onspring.API.SDK.Models;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve an app by ID.
    /// </summary>
    public interface IGetAppByIdRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the app to retrieve.
        /// </summary>
        int AppId { get; }

        /// <summary>
        /// Asynchronously sends the request to retrieve the app.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{App}"/> when complete.</returns>
        Task<ApiResponse<App>> SendAsync();
    }
}