namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to add a file.
    /// </summary>
    public interface IAddFileRequestBuilder
    {
        /// <summary>
        /// Specifies the ID of the record to add the file to.
        /// </summary>
        /// <param name="recordId">The ID of the record to add the file to.</param>
        /// <returns>A <see cref="IAddFileToRecordRequestBuilder"/> for further configuration of the request.</returns>
        IAddFileToRecordRequestBuilder ToRecord(int recordId);
    }
}