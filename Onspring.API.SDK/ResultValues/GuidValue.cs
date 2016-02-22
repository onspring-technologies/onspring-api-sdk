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
    public class GuidValue: ResultValue
    {
        public GuidValue(Guid? value)
        {
            Value = value;
        }

        public override ResultValueType Type => ResultValueType.Guid;

        public Guid? Value { get; private set; }

    }

}