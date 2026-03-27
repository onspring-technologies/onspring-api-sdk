using System.IO;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to add a file with a stream.
    /// </summary>
    public interface IAddFileWithStreamRequestBuilder
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
        /// Gets the stream of the file to add.
        /// </summary>
        Stream FileStream { get; }

        /// <summary>
        /// Specifies the MIME type of the file to add.
        /// </summary>
        /// <param name="type">The MIME type of the file to add.</param>
        /// <returns>A <see cref="IAddFileWithTypeRequestBuilder"/> for further configuration of the request.</returns>
        IAddFileWithTypeRequestBuilder WithType(string type);
    }
}