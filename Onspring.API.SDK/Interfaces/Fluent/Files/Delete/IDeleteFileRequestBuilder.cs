namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to delete a file.
    /// </summary>
    public interface IDeleteFileRequestBuilder
    {
        /// <summary>
        /// Specifies the ID of the record to delete the file from.
        /// </summary>
        /// <param name="recordId">The ID of the record to delete the file from.</param>
        /// <returns>A <see cref="IDeleteFileFromRecordRequestBuilder"/> for further configuration of the request.</returns>
        IDeleteFileFromRecordRequestBuilder FromRecord(int recordId);
    }
}