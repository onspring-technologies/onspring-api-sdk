using Microsoft.AspNetCore.Http;
using System;

namespace Onspring.API.SDK.Tests.TestServer.Models
{
    public class ApiSaveFileRequest
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
        /// File's associated notes.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Modification date of the file.
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// File used in upload.
        /// </summary>
        public IFormFile File { get; set; }
    }
}
