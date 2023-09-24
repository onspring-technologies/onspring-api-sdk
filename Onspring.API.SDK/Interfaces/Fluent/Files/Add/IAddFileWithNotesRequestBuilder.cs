using System;
using System.IO;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to add a file with notes.
    /// </summary>
    public interface IAddFileWithNotesRequestBuilder
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
        /// Gets the MIME type of the file to add.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets the notes of the file to add.
        /// </summary>
        string Notes { get; }

        /// <summary>
        /// Specifies the modified date of the file to add.
        /// </summary>
        /// <param name="modifiedDate">The modified date of the file to add.</param>
        /// <returns>A <see cref="IAddFileWithModifiedDateRequestBuilder"/> for further configuration of the request.</returns>
        IAddFileWithModifiedDateRequestBuilder WithModifiedDate(DateTime? modifiedDate);
    }
}