namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve a file from a record.
    /// </summary>
    public interface IGetFileFromRecordRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the record to retrieve the file from.
        /// </summary>
        int RecordId { get; }

        /// <summary>
        /// Specifies the ID of the field to retrieve the file from.
        /// </summary>
        /// <param name="fieldId">The ID of the field to retrieve the file from.</param>
        /// <returns>A <see cref="IGetFileInFieldRequestBuilder"/> for further configuration of the request.</returns>
        IGetFileInFieldRequestBuilder InField(int fieldId);
    }
}