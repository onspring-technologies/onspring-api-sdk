#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.ResultValues
{
    public class TimeSpanValue : ResultValue
    {
        public TimeSpanValue(TimeSpanData value)
        {
            Value = value;
        }

        public override ResultValueType Type => ResultValueType.TimeSpan;

        public TimeSpanData Value { get; private set; }

    }

}