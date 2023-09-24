namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to delete a file from a field.
    /// </summary>
    public interface IDeleteFileInFieldRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the record to delete the file from.
        /// </summary>
        int RecordId { get; }

        /// <summary>
        /// Gets the ID of the field to delete the file from.
        /// </summary>
        int FieldId { get; }

        /// <summary>
        /// Specifies the ID of the file to delete.
        /// </summary>
        /// <param name="fileId">The ID of the file to delete.</param>
        /// <returns>A <see cref="IDeleteFileByIdRequestBuilder"/> for further configuration of the request.</returns>
        IDeleteFileByIdRequestBuilder WithId(int fileId);
    }
}