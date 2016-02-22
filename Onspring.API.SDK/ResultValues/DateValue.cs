#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
using System;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.ResultValues
{
    public class DateValue: ResultValue
    {
        public DateValue(DateTime? value)
        {
            Value = value;
        }

        public override ResultValueType Type => ResultValueType.Date;

        public DateTime? Value { get; private set; }

    }

}