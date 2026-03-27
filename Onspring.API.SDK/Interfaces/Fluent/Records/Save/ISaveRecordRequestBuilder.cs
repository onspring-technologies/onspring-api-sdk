namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to save a record.
    /// </summary>
    public interface ISaveRecordRequestBuilder
    {
        /// <summary>
        /// Specifies the app in which to save the record.
        /// </summary>
        /// <param name="appId">The ID of the app in which to save the record.</param>
        /// <returns>A <see cref="ISaveRecordInAppRequestBuilder"/> for further configuration of the request.</returns>
        ISaveRecordInAppRequestBuilder InApp(int appId);
    }
}