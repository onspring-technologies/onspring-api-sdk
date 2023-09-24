namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve information about a file in a field.
    /// </summary>
    public interface IGetFileInfoInFieldRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the record to retrieve the file information from.
        /// </summary>
        int RecordId { get; }

        /// <summary>
        /// Gets the ID of the field to retrieve the file information from.
        /// </summary>
        int FieldId { get; }

        /// <summary>
        /// Specifies the ID of the file to retrieve information about.
        /// </summary>
        /// <param name="fileId">The ID of the file to retrieve information about.</param>
        /// <returns>A <see cref="IGetFileInfoByIdRequestBuilder"/> for further configuration of the request.</returns>
        IGetFileInfoByIdRequestBuilder WithId(int fileId);
    }
}