using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    public class FileListFieldValue : RecordFieldValue
    {
        public List<int> Value { get; set; } = new List<int>();

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
