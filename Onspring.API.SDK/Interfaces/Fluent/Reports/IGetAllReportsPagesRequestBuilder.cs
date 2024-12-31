namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Interface for building requests to get all pages of reports.
    /// </summary>
    public interface IGetAllReportsPagesRequestBuilder
    {
        /// <summary>
        /// Sets the app ID for the request.
        /// </summary>
        /// <param name="appId">The app ID.</param>
        /// <returns>A <see cref="IGetAllReportsPagesByAppRequestBuilder"/> for further configuration of the request.</returns>
        IGetAllReportsPagesByAppRequestBuilder FromApp(int appId);
    }
}