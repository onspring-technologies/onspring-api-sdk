using System;
using System.IO;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a response to getting a file.
    /// </summary>
    public class GetFileResponse : IDisposable
    {
        /// <summary>
        /// Gets or sets the stream containing file data.
        /// </summary>
        public Stream Stream { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the length of the content.
        /// </summary>
        public long ContentLength { get; set; }

        /// <summary>
        /// Disposes of the <see cref="Stream"/>.
        /// </summary>
        public void Dispose()
        {
            Stream?.Dispose();
        }
    }
}
