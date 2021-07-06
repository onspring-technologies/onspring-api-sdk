using System;
using System.IO;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a response to getting a file.
    /// </summary>
    public class GetFileResponse : IDisposable
    {
        public Stream Stream { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long ContentLength { get; set; }

        public void Dispose()
        {
            Stream?.Dispose();
        }
    }
}
