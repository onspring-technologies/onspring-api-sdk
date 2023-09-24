using Onspring.API.SDK.Models;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetPagedAppsRequestBuilder
    {
        /// <summary>
        /// Gets the page number of the apps to retrieve.
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        ///  Gets the page size of the apps to retrieve. The default is 50.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Specifies the page size of the apps to retrieve.
        /// </summary>
        /// <param name="pageSize">The page size of the apps to retrieve.</param>
        /// <returns>A <see cref="IGetPagedAppsRequestBuilder"/> for further configuration of the request.</returns>
        IGetPagedAppsRequestBuilder WithPageSize(int pageSize);

        /// <summary>
        /// Asynchronously sends the request to retrieve the apps.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{GetPagedAppsResponse}"/> when complete.</returns>
        Task<ApiResponse<GetPagedAppsResponse>> SendAsync();
    }
}