using System.IO;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to add a file with a name.
    /// </summary>
    public interface IAddFileWithNameRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the record to add the file to.
        /// </summary>
        int RecordId { get; }

        /// <summary>
        /// Gets the ID of the field to add the file to.
        /// </summary>
        int FieldId { get; }

        /// <summary>
        /// Gets the name of the file to add.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Specifies the Stream of the file to add.
        /// </summary>
        /// <param name="stream">The Stream of the file to add.</param>
        /// <returns>A <see cref="IAddFileWithStreamRequestBuilder"/> for further configuration of the request.</returns>
        IAddFileWithStreamRequestBuilder WithStream(Stream stream);
    }
}