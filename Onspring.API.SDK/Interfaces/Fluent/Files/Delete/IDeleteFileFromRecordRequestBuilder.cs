namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to delete a file from a record.
    /// </summary>
    public interface IDeleteFileFromRecordRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the record to delete the file from.
        /// </summary>
        int RecordId { get; }

        /// <summary>
        /// Specifies the ID of the field to delete the file from.
        /// </summary>
        /// <param name="fieldId">The ID of the field to delete the file from.</param>
        /// <returns>A <see cref="IDeleteFileInFieldRequestBuilder"/> for further configuration of the request.</returns>
        IDeleteFileInFieldRequestBuilder InField(int fieldId);
    }
}