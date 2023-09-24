namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve a file.
    /// </summary>
    public interface IGetFileRequestBuilder
    {
        /// <summary>
        /// Specifies the ID of the file to retrieve.
        /// </summary>
        /// <param name="recordId">The ID of the record to retrieve the file from.</param>
        /// <returns>A <see cref="IGetFileFromRecordRequestBuilder"/> for further configuration of the request.</returns>
        IGetFileFromRecordRequestBuilder FromRecord(int recordId);
    }
}