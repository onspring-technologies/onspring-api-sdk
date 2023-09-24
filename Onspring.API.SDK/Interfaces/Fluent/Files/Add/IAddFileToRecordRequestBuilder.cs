namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to add a file to a record.
    /// </summary>
    public interface IAddFileToRecordRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the record to add the file to.
        /// </summary>
        int RecordId { get; }

        /// <summary>
        /// Specifies the ID of the field to add the file to.
        /// </summary>
        /// <param name="fieldId">The ID of the field to add the file to.</param>
        /// <returns>A <see cref="IAddFileInFieldRequestBuilder"/> for further configuration of the request.</returns>
        IAddFileInFieldRequestBuilder InField(int fieldId);
    }
}