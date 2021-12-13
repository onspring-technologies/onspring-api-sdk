using System;
using System.IO;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a request to save a file.
    /// </summary>
    public class SaveFileRequest : IDisposable
    {
        /// <summary>
        /// Record identifier.
        /// </summary>
        public int RecordId { get; set; }

        /// <summary>
        /// Field identifier.
        /// </summary>
        public int FieldId { get; set; }

        /// <summary>
        /// Gets or sets the file's notes.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the modified date of the file, if any.
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the file's name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the MIME content type of the file. Example: image/png
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the file (read) stream.
        /// </summary>
        public Stream FileStream { get; set; }

        public void Dispose()
        {
            FileStream?.Dispose();
        }
    }
}
