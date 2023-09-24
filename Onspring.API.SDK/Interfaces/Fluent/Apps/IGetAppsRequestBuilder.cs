using System.Collections.Generic;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve apps.
    /// </summary>
    public interface IGetAppsRequestBuilder
    {
        /// <summary>
        /// Specifies the page number to retrieve.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve.</param>
        /// <returns>A <see cref="IGetPagedAppsRequestBuilder"/> for further configuration of the request.</returns>
        IGetPagedAppsRequestBuilder ForPage(int pageNumber);

        /// <summary>
        /// Specifies the IDs of the apps to retrieve.
        /// </summary>
        /// <param name="appIds">The IDs of the apps to retrieve.</param>
        /// <returns>A <see cref="IGetAppsByIdsRequestBuilder"/> for further configuration of the request.</returns>
        IGetAppsByIdsRequestBuilder WithIds(IEnumerable<int> appIds);

        /// <summary>
        /// Specifies the ID of the app to retrieve.
        /// </summary>
        /// <param name="appId">The ID of the app to retrieve.</param>
        /// <returns>A <see cref="IGetAppByIdRequestBuilder"/> for further configuration of the request.</returns>
        IGetAppByIdRequestBuilder WithId(int appId);
    }
}