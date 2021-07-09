using Onspring.API.SDK.Enums;
using System;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Response including a file's information.
    /// </summary>
    public class GetFileInfoResponse
    {
        /// <summary>
        /// Represents the type of file.
        /// </summary>
        public FieldType Type { get; set; }

        /// <summary>
        /// Represents the file's content type.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Name of the file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Date the file was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Date the file was modified.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Owner of the file.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// File's description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// URI to the file's data.
        /// </summary>
        public string FileHref { get; set; }
    }
}
