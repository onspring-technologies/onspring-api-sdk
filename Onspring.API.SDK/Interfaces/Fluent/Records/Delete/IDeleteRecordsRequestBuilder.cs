namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to delete records.
    /// </summary>
    public interface IDeleteRecordsRequestBuilder
    {
        /// <summary>
        /// Specifies the app from which to delete records.
        /// </summary>
        /// <param name="appId">The ID of the app from which to delete records.</param>
        /// <returns>A <see cref="IDeleteRecordsByAppRequestBuilder"/>  for further configuration of the request.</returns>
        IDeleteRecordsByAppRequestBuilder FromApp(int appId);
    }
}