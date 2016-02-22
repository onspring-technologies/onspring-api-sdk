#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
using Onspring.API.SDK.ResultValues;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Wraps a result record value with its field id (used for enumerating all values)
    /// </summary>
    public class FieldValueWrapper
    {
        public FieldValueWrapper(int fieldId, ResultValue value)
        {
            FieldId = fieldId;
            Value = value;
        }

        public int FieldId { get; private set; }
        public ResultValue Value { get; private set; }

    }
}