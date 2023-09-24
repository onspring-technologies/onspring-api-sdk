namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve a file from a field.
    /// </summary>
    public interface IGetFileInFieldRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the record to retrieve the file from.
        /// </summary>
        int RecordId { get; }

        /// <summary>
        /// Gets the ID of the field to retrieve the file from.
        /// </summary>
        int FieldId { get; }

        /// <summary>
        /// Specifies the ID of the file to retrieve.
        /// </summary>
        /// <param name="fileId">The ID of the file to retrieve.</param>
        /// <returns>A <see cref="IGetFileByIdRequestBuilder"/> for further configuration of the request.</returns>
        IGetFileByIdRequestBuilder WithId(int fileId);
    }
}