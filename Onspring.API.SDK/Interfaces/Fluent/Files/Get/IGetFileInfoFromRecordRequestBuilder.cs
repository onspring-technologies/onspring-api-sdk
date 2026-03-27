namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve information about a file from a record.
    /// </summary>
    public interface IGetFileInfoFromRecordRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the record to retrieve the file information from.
        /// </summary>
        int RecordId { get; }

        /// <summary>
        /// Specifies the ID of the field to retrieve the file information from.
        /// </summary>
        /// <param name="fieldId">The ID of the field to retrieve the file information from.</param>
        /// <returns>A <see cref="IGetFileInfoInFieldRequestBuilder"/> for further configuration of the request.</returns>
        IGetFileInfoInFieldRequestBuilder InField(int fieldId);
    }
}