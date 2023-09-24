namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve records.
    /// </summary>
    public interface IGetRecordsRequestBuilder
    {
        /// <summary>
        /// Specifies the app from which to retrieve records.
        /// </summary>
        /// <param name="appId">The unique identifier of the app.</param>
        /// <returns>A builder <see cref="IGetRecordsByAppRequestBuilder"/> for further configuration of the request.</returns>
        IGetRecordsByAppRequestBuilder FromApp(int appId);
    }
}