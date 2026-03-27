namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Interface for building paged requests.
    /// </summary>
    public interface IPagedRequestBuilder
    {
        /// <summary>
        /// Creates a builder to get all pages of apps.
        /// </summary>
        /// <returns>A <see cref="IGetAllAppsPagesRequestBuilder"/> for further configuration of the request.</returns>
        IGetAllAppsPagesRequestBuilder OfApps();

        /// <summary>
        /// Creates a builder to get all pages of fields for a specific app.
        /// </summary>
        /// <returns>A <see cref="IGetAllFieldsPagesRequestBuilder"/> for further configuration of the request.</returns>
        IGetAllFieldsPagesRequestBuilder OfFields();

        /// <summary>
        /// Creates a builder to get all pages of records for a specific app.
        /// </summary>
        /// <returns>A <see cref="IGetAllRecordsPagesRequestBuilder"/> for further configuration of the request.</returns>
        IGetAllRecordsPagesRequestBuilder OfRecords();

        /// <summary>
        /// Creates a builder to get all pages of reports for a specific app.
        /// </summary>
        /// <returns>A <see cref="IGetAllReportsPagesRequestBuilder"/> for further configuration of the request.</returns>
        IGetAllReportsPagesRequestBuilder OfReports();
    }
}