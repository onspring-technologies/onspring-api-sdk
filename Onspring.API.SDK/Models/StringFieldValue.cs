#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a field value comprised of a string value.
    /// </summary>
    public class StringFieldValue : RecordFieldValue<string>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="StringFieldValue"/>.
        /// </summary>
        public StringFieldValue()
        {
            Type = Enums.ResultValueType.String;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="StringFieldValue"/>.
        /// </summary>
        public StringFieldValue(int fieldId, string value) : this()
        {
            FieldId = fieldId;
            Value = value;
        }
    }
}