namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to get reports.
    /// </summary>
    public interface IGetReportsRequestBuilder
    {
        /// <summary>
        /// Specifies the ID of the app from which to get reports.
        /// </summary>
        /// <param name="appId">The ID of the app from which to get reports.</param>
        /// <returns>A <see cref="IGetReportsByAppRequestBuilder"/> for further configuration of the request.</returns>
        IGetReportsByAppRequestBuilder FromApp(int appId);
    }
}