namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to save a record in an app.
    /// </summary>
    public interface ISaveRecordInAppRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the app in which to save the record.
        /// </summary>
        int AppId { get; }

        /// <summary>
        /// Specifies the record to save. If the record ID is null, a new record will be created.
        /// </summary>
        /// <param name="recordId">The ID of the record to save.</param>
        /// <returns>A <see cref="ISaveRecordByIdRequestBuilder"/> for further configuration of the request.</returns>
        ISaveRecordByIdRequestBuilder WithId(int? recordId);
    }
}