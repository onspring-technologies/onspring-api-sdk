using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a field value comprised of a collection of file identifier values.
    /// </summary>
    public class FileListFieldValue : RecordFieldValue<List<int>>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="FileListFieldValue"/>.
        /// </summary>
        public FileListFieldValue()
        {
            Type = Enums.ResultValueType.FileList;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="FileListFieldValue"/>.
        /// </summary>
        public FileListFieldValue(int fieldId, List<int> value) : this()
        {
            FieldId = fieldId;
            Value = value;
        }
    }
}
