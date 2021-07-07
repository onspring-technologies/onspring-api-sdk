using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    public class AttachmentListFieldValue : RecordFieldValue
    {
        public List<AttachmentFile> Value { get; set; } = new List<AttachmentFile>();

        /// <summary>
        /// Initializes a new instance of <see cref="AttachmentListFieldValue"/>.
        /// </summary>
        public AttachmentListFieldValue()
        {
            Type = Enums.ResultValueType.AttachmentList;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="AttachmentListFieldValue"/>.
        /// </summary>
        public AttachmentListFieldValue(int fieldId, List<AttachmentFile> value) : this()
        {
            FieldId = fieldId;
            Value = value;
        }
    }
}
