﻿#region Copyright
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
    public class IntegerValue: ResultValue
    {
        public IntegerValue(int? value)
        {
            Value = value;
        }

        public override ResultValueType Type => ResultValueType.Integer;

        public int? Value { get; private set; }

    }

}