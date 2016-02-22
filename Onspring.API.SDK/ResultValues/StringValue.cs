#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.ResultValues
{
    public class StringValue: ResultValue
    {
        public StringValue(string value)
        {
            Value = value;
        }

        public override ResultValueType Type => ResultValueType.String;

        public string Value { get; private set; }

    }

}