using System;
using System.IO;
using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IAddFileWithModifiedDateRequestBuilder
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
        /// Gets the modified date of the file to add.
        /// </summary>
        DateTime? ModifiedDate { get; }

        /// <summary>
        /// Asynchronously sends the request to add the file.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{CreatedWithIdResponse}"/> when completed</returns>
        Task<ApiResponse<CreatedWithIdResponse<int>>> SendAsync();
    }
}