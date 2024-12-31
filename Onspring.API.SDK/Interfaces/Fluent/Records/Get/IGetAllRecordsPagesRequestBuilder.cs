namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a request builder for getting all pages of records.
    /// </summary>
    public interface IGetAllRecordsPagesRequestBuilder
    {
        /// <summary>
        /// Specifies the app to retrieve records from.
        /// </summary>
        /// <param name="appId">The ID of the app to retrieve records from.</param>
        /// <returns>A <see cref="IGetAllRecordsPagesByAppRequestBuilder"/> for further configuration of the request.</returns>
        IGetAllRecordsPagesByAppRequestBuilder FromApp(int appId);
    }
}