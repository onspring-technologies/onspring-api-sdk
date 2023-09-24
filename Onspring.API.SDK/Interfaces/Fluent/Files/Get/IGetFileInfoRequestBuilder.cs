namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve information about a file.
    /// </summary>
    public interface IGetFileInfoRequestBuilder
    {
        /// <summary>
        /// Specifies the ID of the record to retrieve the file information from.
        /// </summary>
        /// <param name="recordId">The ID of the record to retrieve the file information from.</param>
        /// <returns>A <see cref="IGetFileInfoFromRecordRequestBuilder"/> for further configuration of the request.</returns>
        IGetFileInfoFromRecordRequestBuilder FromRecord(int recordId);
    }
}