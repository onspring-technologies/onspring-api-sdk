#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a field value comprised of a collection of <see cref="AttachmentFile"/> values.
    /// </summary>
    public class AttachmentListFieldValue : RecordFieldValue<List<AttachmentFile>>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AttachmentListFieldValue"/>.
        /// </summary>
        public AttachmentListFieldValue()
        {
            Type = Enums.ResultValueType.AttachmentList;
            Value = new List<AttachmentFile>();
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
