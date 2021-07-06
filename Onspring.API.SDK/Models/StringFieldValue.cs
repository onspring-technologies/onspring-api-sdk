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
    public class StringFieldValue : RecordFieldValue
    {
        public string Value { get; set; }

        public StringFieldValue()
        {
            Type = Enums.ResultValueType.String;
        }

        public StringFieldValue(string value) : this()
        {
            Value = value;
        }
    }
}