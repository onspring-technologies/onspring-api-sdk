using System;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a request to save a file.
    /// </summary>
    public class SaveFileRequest
    {
        public int RecordId { get; set; }
        public int FieldId { get; set; }
        public string Notes { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string FileName { get; set; }
        public byte[] FileContents { get; set; }
    }
}
